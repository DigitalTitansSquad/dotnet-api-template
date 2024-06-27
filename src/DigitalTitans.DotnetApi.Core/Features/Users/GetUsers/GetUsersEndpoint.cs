using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace DigitalTitans.DotnetApi.Core.Features.Users.GetUsers;

public static class GetUsersEndoint
{
    public static void AddGetUsersEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/users", 
            [Authorize]
            [UserSwaggerOperation]
            async (IMediator mediator) =>
        {
            var query = new GetUsersQuery();
            return await mediator.Send(query);
        });
    }
}
