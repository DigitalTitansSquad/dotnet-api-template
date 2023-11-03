using System.Threading.Tasks;

namespace DigitalTitans.DotnetApi.Common.Interfaces;

public interface IUserProvider
{
    Task<string> GetCurrentUserIdAsync();
    Task<string?> GetCurrentUserIdOrDefaultAsync();
}