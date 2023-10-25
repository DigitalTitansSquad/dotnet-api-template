using System;
namespace DotnetApi.Core.Models
{
    public interface IEntity { }

    public interface IRootEntity : IEntity
    {
        string Id { get; set; }
    }

    public interface IAuditableEntity : IRootEntity
    {
        DateTimeOffset CreatedAtUtc { get; set; }
        DateTimeOffset? LastUpdatedAtUtc { get; set; }
    }
}

