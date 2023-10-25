using System;
namespace DotnetApi.Core.Models
{
    public class UserEntity : IRootEntity
    {
        public string Id { get; set; } = default!;
        public DateTimeOffset CreatedAtUtc { get; set; }
        public DateTimeOffset? LastUpdatedAtUtc { get; set; }
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string ExternalId { get; set; } = default!;
        public string? ProfilePictureUrl { get; set; } 
    }
}