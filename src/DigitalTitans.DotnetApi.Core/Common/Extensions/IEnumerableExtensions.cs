using System;
using DigitalTitans.DotnetApi.Core.Common.Api;

namespace DigitalTitans.DotnetApi.Core.Common.Extensions;

public static class IEnumerableExtensions
{
    public static Page<T> ToPage<T>(this IEnumerable<T> collection, int totalCount)
    {
        return new Page<T>(
            totalCount: totalCount,
            items: collection.ToList());
    }
}