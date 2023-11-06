using System;
using AutoMapper;
using DigitalTitans.DotnetApi.Common.Api;
using DigitalTitans.DotnetApi.Common.Exceptions;
using DigitalTitans.DotnetApi.Common.Interfaces;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using DigitalTitans.DotnetApi.Core.DomainEvents;
using DigitalTitans.DotnetApi.Core.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DigitalTitans.DotnetApi.Core.Features.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        [SwaggerIgnore]
        public string Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        [SwaggerIgnore]
        public string ExternalId { get; set; } = default!;
        public string? ProfilePictureUrl { get; set; } = default!;
    }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty();

            RuleFor(x => x.ExternalId)
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();
        }
    }

    public class CreateUserCommandHandler(IDbContext dbContext, IMapper mapper, IDateTimeOffsetProvider dateTimeOffsetProvider, IMediator mediator) : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IDbContext dbContext = dbContext;
        private readonly IMapper mapper = mapper;
        private readonly IDateTimeOffsetProvider dateTimeOffsetProvider = dateTimeOffsetProvider;
        private readonly IMediator mediator = mediator;

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.ExternalId == request.ExternalId, cancellationToken: cancellationToken);

            if (existingUser != null)
            {
                throw DuplicateResourceException.Create<UserEntity>();
            }

            var user = mapper.Map<UserEntity>(request);

            user.CreatedAtUtc = dateTimeOffsetProvider.GetUtcNow();

            await dbContext.Users.AddAsync(user, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            await mediator.Publish(new UserCreatedEvent(
                user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                user.ExternalId,
                user.ProfilePictureUrl
            ), cancellationToken);

            return user.Id;
        }
    }
}

