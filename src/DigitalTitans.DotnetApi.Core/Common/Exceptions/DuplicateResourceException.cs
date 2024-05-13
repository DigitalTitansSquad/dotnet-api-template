using System;
namespace DigitalTitans.DotnetApi.Core.Common.Exceptions
{
    public class DuplicateResourceException(string resourceName) : Exception
    {
        public string ResourceName { get; set; } = resourceName;

        public static DuplicateResourceException Create<T>() => new(typeof(T).Name);   
    }
}

