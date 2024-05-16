using DigitalTitans.AuctionNest.IntegrationTests.Extensions;
using DigitalTitans.DotnetApi.Core.Features.Users.UpdateUser;
using DigitalTitans.DotnetApi.Core.Models;
using DigitalTitans.DotnetApi.Mocks.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http.Json;

namespace DigitalTitans.AuctionNest.IntegrationTests.UserTests;

public class UpdateUserTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
    private readonly IntegrationTestWebAppFactory _factory = factory;

    [Fact]
    public async Task UpdateUser_WhenUserExists_ShouldUpdateUser()
    {
        // Arrange
        var userId = IdGenerator.GenerateId();
        var externalUserId = IdGenerator.GenerateExternalId();
        var existingUser = new UserEntity
        {
            Id = userId,
            FirstName = "John",
            LastName = "Doe",
            Email = "john_doe@gmailcom",
            ExternalId = externalUserId
        };

        DbContext.Users.Add(existingUser);

        await DbContext.SaveChangesAsync();

        var updateUserCommand = new UpdateUserCommand
        {
            Id = userId,
            FirstName = "Jane",
            LastName = "Doe",
            Email = "john_doe@gmailcom"
        };

        var httpClient = _factory.CreateClient();
        httpClient.DefaultRequestHeaders.Add(TestAuthHandler.UserId, externalUserId);

        // Act
        var response = await httpClient.PutAsJsonAsync($"/api/users/{userId}", updateUserCommand);

        // Assert
        DbContext.ReloadAllEntities();

        var user = await DbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        user.Should().NotBeNull();
        user?.FirstName.Should().Be(updateUserCommand.FirstName);
        user?.LastName.Should().Be(updateUserCommand.LastName);
    }
}
