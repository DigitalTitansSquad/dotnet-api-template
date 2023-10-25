using MediatR;

namespace DotnetApi.Core.DomainEvents;

public record UserCreatedEvent : INotification
{
    public UserCreatedEvent(
        string id, 
        string email, 
        string firstName, 
        string lastName, 
        string externalId, 
        string? profilePictureUrl)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        ExternalId = externalId;
        ProfilePictureUrl = profilePictureUrl;
    }

    public string Id { get; init; }
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string ExternalId { get; init; }
    public string? ProfilePictureUrl { get; init; }
}