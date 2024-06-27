using DigitalTitans.DotnetApi.Core.Features.Users.CreateUser;
using DigitalTitans.DotnetApi.Core.Features.Users.GetUsers;
using DigitalTitans.DotnetApi.Core.Features.Users.UpdateUser;
using Microsoft.AspNetCore.Routing;

namespace DigitalTitans.DotnetApi.Core.Features.Users;

public static class UserExtensions
{
    public static void AddUserEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.AddCreateUserEndpoint();
        endpoints.AddUpdateUserEndpoint();
        endpoints.AddGetUsersEndpoint();
    }
}