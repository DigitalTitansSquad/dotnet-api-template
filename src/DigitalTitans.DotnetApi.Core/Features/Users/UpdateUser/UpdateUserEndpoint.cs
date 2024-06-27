
using DigitalTitans.DotnetApi.Core.Common.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace DigitalTitans.DotnetApi.Core.Features.Users.UpdateUser;

public static class UpdateUserEndpoint
{
    public static void AddUpdateUserEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("/api/users/{id}",
            [Authorize(Policy = PolicyNames.DefaultPolicy)]
            [UserSwaggerOperation]
            async (IMediator mediator, long id, UpdateUserCommand command) =>
        {
            command.Id = id;
            await mediator.Send(command);
        });
    }
}
