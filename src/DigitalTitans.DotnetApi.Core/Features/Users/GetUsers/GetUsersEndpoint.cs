using DigitalTitans.DotnetApi.Core.Common.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace DigitalTitans.DotnetApi.Core.Features.Users.GetUsers;

public static class GetUsersEndoint
{
    public static void AddGetUsersEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/users", 
            [Authorize (Policy = PolicyNames.DefaultPolicy)]
            [UserSwaggerOperation]
            async (IMediator mediator, [AsParameters] GetUsersQuery query) => 
            await mediator.Send(query));
    }
}
