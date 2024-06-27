using DigitalTitans.DotnetApi.Core.Common.Auth;
using DigitalTitans.DotnetApi.Core.Common.Exceptions;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

namespace DigitalTitans.DotnetApi.Core.Features.Users.CreateUser;

public static class CreateUserEndpoint
{
    public static void AddCreateUserEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/users/me", 
            [Authorize(Policy = PolicyNames.DefaultPolicy)] 
            [UserSwaggerOperation] 
            async (IMediator mediator, IClaimProvider claimProvider) =>
        {
            var command = new CreateUserCommand
            {
                Email = claimProvider.GetUserClaim(System.Security.Claims.ClaimTypes.Email) ?? throw new AuthorizationException("Email not found in claims."),
                FirstName = claimProvider.GetUserClaim(System.Security.Claims.ClaimTypes.GivenName) ?? throw new BadRequestException("First name not found in claims."),
                LastName = claimProvider.GetUserClaim(System.Security.Claims.ClaimTypes.Surname) ?? throw new BadRequestException("Last name not found in claims."),
                ExternalId = claimProvider.GetUserClaim(System.Security.Claims.ClaimTypes.NameIdentifier) ?? throw new AuthorizationException("User id not found in claims.")
            };

            return await mediator.Send(command);
        })
        .Produces<long>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .WithOpenApi();
    }
}


