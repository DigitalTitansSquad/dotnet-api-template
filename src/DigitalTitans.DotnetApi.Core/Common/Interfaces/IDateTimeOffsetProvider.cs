namespace DigitalTitans.DotnetApi.Core.Common.Interfaces;

public interface IDateTimeOffsetProvider
{
    DateTimeOffset GetUtcNow();
}