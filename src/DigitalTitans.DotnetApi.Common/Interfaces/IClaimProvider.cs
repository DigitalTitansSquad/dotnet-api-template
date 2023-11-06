namespace DigitalTitans.DotnetApi.Common.Interfaces;

public interface IClaimProvider
{
    string? GetUserClaim(string claimType);
}