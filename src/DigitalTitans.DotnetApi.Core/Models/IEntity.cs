using System;
namespace DigitalTitans.DotnetApi.Core.Models
{
    public interface IEntity { }

    public interface IRootEntity : IEntity
    {
        long Id { get; set; }
    }

    public interface IAuditableEntity : IRootEntity
    {
        DateTime CreatedAtUtc { get; set; }
        DateTime? LastUpdatedAtUtc { get; set; }
    }
}

