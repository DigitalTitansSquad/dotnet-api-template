namespace DigitalTitans.DotnetApi.Common.Interfaces;

public interface IDateTimeOffsetProvider
{
    DateTimeOffset GetUtcNow();
}