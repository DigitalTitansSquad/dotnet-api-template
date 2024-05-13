using System.Security.Claims;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DigitalTitans.DotnetApi.Infrastructure.Services
{
    public class ClaimProvider(IHttpContextAccessor httpContextAccessor) : IClaimProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string? GetUserClaim(string claimType)
        {
            return _httpContextAccessor
            .HttpContext?
            .User?
            .Claims?
            .FirstOrDefault(c => c.Type == claimType)?
            .Value;
        }
    }
}