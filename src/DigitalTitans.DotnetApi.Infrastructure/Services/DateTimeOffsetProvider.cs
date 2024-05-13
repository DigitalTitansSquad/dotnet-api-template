
using System;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
namespace DigitalTitans.DotnetApi.Infrastructure.Services
{
    public class DateTimeOffsetProvider : IDateTimeOffsetProvider
    {
        public DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;
    }
}

