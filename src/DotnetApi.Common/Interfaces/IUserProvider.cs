namespace DotnetApi.Common.Interfaces;

public interface IUserProvider
{
    Task<string> GetCurrentUserIdAsync();
    Task<string?> GetCurrentUserIdOrDefaultAsync();
}