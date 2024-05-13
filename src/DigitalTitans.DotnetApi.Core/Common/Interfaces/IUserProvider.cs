using System.Threading.Tasks;

namespace DigitalTitans.DotnetApi.Core.Common.Interfaces;

public interface IUserProvider
{
    Task<string> GetCurrentUserIdAsync();
    Task<string?> GetCurrentUserIdOrDefaultAsync();
}