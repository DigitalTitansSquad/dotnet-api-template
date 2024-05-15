
using System;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
namespace DigitalTitans.DotnetApi.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetUtcNow() => DateTime.UtcNow;
    }
}

