
namespace DigitalTitans.DotnetApi.Core.Features.GetUsers;

public class GetUsersReadModel
{
    public string Id { get; set; } = default!;
    public DateTimeOffset CreatedAtUtc { get; set; }
    public DateTimeOffset? UpdatedAtUtc { get; set; }
    public DateTimeOffset? LastUpdatedAtUtc { get; set; }
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string ExternalId { get; set; } = default!;
    public string? ProfilePictureUrl { get; set; }
    public string? CurrencyCode { get; set; }
}