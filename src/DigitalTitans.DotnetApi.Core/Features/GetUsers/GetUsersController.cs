using System;
using DigitalTitans.DotnetApi.Common.Api;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalTitans.DotnetApi.Core.Features.GetUsers
{
    [Route("api/users")]
    [Authorize] //TODO: add admin policy for this endpoint
    public class GetUsersController : ControllerBase
    {
        private IMediator mediator;

        public GetUsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IPage<UserSummaryReadModel>> GetPageAsync(GetUsersQuery query)
        {
            return await mediator.Send(query);
        }
    }
}

