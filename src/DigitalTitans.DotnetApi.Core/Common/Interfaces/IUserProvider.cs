using System.Threading.Tasks;

namespace DigitalTitans.DotnetApi.Core.Common.Interfaces;

public interface IUserProvider
{
    Task<long> GetCurrentUserIdAsync();
    Task<long?> GetCurrentUserIdOrDefaultAsync();
}