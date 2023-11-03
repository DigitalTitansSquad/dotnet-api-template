using System;
using AutoMapper;
using DigitalTitans.DotnetApi.Common.Api;
using DigitalTitans.DotnetApi.Common.Extensions;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using DigitalTitans.DotnetApi.Core.Models;
using FluentValidation;
using MediatR;

namespace DigitalTitans.DotnetApi.Core.Features.GetUsers
{
    public class GetUsersQuery :
        PageAndSortFilter,
        IRequest<IPage<UserSummaryReadModel>>
    {
        public string? Text { get; set; }
        public string? ExternalId { get; set; }
    }

    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator()
        {
            RuleFor(x => x.PageIndex)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(50);
        }
    }

    public class GetUsersQueryHandler(IDbContext dbContext, IMapper mapper) : IRequestHandler<GetUsersQuery, IPage<UserSummaryReadModel>>
    {
        private readonly IDbContext dbContext = dbContext;
        private readonly IMapper mapper = mapper;

        public async Task<IPage<UserSummaryReadModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = dbContext
                .Users
                .AsQueryable();

            if (request.ExternalId is not null)
            {
                query = query.Where(u => u.ExternalId == request.ExternalId);
            }

            if (request.Text is not null)
            {
                query = query.Where(u =>
                    u.Email.StartsWith(request.Text) ||
                    u.FirstName.StartsWith(request.Text) ||
                    u.LastName.StartsWith(request.Text));
            }

            return await query
                .OrderBy(request)
                .ProjectToPageAsync<UserSummaryReadModel>(mapper.ConfigurationProvider, request.PageIndex, request.PageSize);
        }
    }

    public class UserSummaryReadModel
    {
        public string Id { get; set; } = default!;
        public DateTimeOffset CreatedAtUtc { get; set; }
        public DateTimeOffset? UpdatedAtUtc { get; set; }
        public DateTimeOffset? LastUpdatedAtUtc { get; set; }
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string ExternalId { get; set; } = default!;
        public string? ProfilePictureUrl { get; set; }
        public string? CurrencyCode { get; set; }

        private class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<UserEntity, UserSummaryReadModel>();
            }
        }
    }
}

