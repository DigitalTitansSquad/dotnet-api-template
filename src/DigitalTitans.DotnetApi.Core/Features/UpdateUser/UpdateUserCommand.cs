using AutoMapper;
using DigitalTitans.DotnetApi.Core.Common.Api;
using DigitalTitans.DotnetApi.Core.Common.Exceptions;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using DigitalTitans.DotnetApi.Core.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalTitans.DotnetApi.Core.Features.UpdateUser;

public class UpdateUserCommand : IRequest
{
    [SwaggerIgnore]
    public string Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    [SwaggerIgnore]
    public string ExternalId { get; set; } = default!;
    public string? ProfilePictureUrl { get; set; } = default!;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateUserCommand, UserEntity>();
        }
    }
}

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
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

public class UpdateUserCommandHandler(
    IDbContext dbContext, 
    IMapper mapper, 
    IDateTimeProvider dateTimeProvider, 
    IMediator mediator) : IRequestHandler<UpdateUserCommand>
{
    private readonly IDbContext dbContext = dbContext;
    private readonly IMapper mapper = mapper;
    private readonly IDateTimeProvider dateTimeProvider = dateTimeProvider;
    private readonly IMediator mediator = mediator;

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.ExternalId == request.ExternalId, cancellationToken: cancellationToken);

        if (user == null)
        {
            throw new ResourceNotFoundException("User not found.");
        }

        mapper.Map(request, user);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}

public class UpdateUserController : ControllerBase
{
    private readonly IMediator mediator;

    public UpdateUserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPut("api/users")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        await mediator.Send(command);

        return Ok();
    }
}