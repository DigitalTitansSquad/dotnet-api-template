using System;
using DotnetApi.Common.Api;

namespace DotnetApi.Common.Extensions;

public static class IEnumerableExtensions
{
    public static Page<T> ToPage<T>(this IEnumerable<T> collection, int totalCount)
    {
        return new Page<T>(
            totalCount: totalCount,
            items: collection.ToList());
    }
}