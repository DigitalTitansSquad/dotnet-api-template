
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using DigitalTitans.DotnetApi.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace DigitalTitans.AuctionNest.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    private readonly IServiceScope _scope;
    protected readonly AppDbContext DbContext;
    protected readonly IDateTimeProvider DateTimeProvider;

    public BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        DbContext = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
        DateTimeProvider = _scope.ServiceProvider.GetRequiredService<IDateTimeProvider>();

        DateTimeProvider.GetUtcNow().Returns(DateTime.UtcNow);
    }
}
