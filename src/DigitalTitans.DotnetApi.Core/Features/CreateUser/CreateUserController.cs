using DigitalTitans.DotnetApi.Core.Common.Auth;
using DigitalTitans.DotnetApi.Core.Common.Exceptions;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalTitans.DotnetApi.Core.Features.CreateUser;

[Route("api/users")]
[Authorize(Policy = PolicyNames.DefaultPolicy)]
public class CreateUserController(IMediator mediator, IClaimProvider claimProvider) : ControllerBase
{
    private readonly IMediator mediator = mediator;
    private readonly IClaimProvider claimProvider = claimProvider;

    [HttpPost]
    public async Task<string> CreateUserAsync([FromBody] CreateUserCommand command)
    {
        command.Id = Guid.NewGuid().ToString();
        command.ExternalId = claimProvider.GetUserClaim(System.Security.Claims.ClaimTypes.NameIdentifier) ?? throw new AuthorizationException("User id not found in claims.");

        return await mediator.Send(command);
    }
}

