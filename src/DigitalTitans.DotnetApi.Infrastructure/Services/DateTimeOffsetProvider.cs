
using System;
using DigitalTitans.DotnetApi.Common.Interfaces;
namespace DigitalTitans.DotnetApi.Infrastructure.Services
{
    public class DateTimeOffsetProvider : IDateTimeOffsetProvider
    {
        public DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;
    }
}

