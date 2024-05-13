namespace DigitalTitans.DotnetApi.Core.Common.Interfaces;

public interface IClaimProvider
{
    string? GetUserClaim(string claimType);
}