using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using NSubstitute;

namespace DigitalTitans.AuctionNest.UnitTests.Extensions;

internal static class IDbContextMock
{
    public static async Task ReceivedSavedChangesAsync(this IDbContext dbContextMock, int times = 1)
    {
        await dbContextMock
            .Received(times)
            .SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}
