
using System;
using DotnetApi.Common.Interfaces;
namespace DotnetApi.Infrastructure.Services
{
    public class DateTimeOffsetProvider : IDateTimeOffsetProvider
    {
        public DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;
    }
}

