namespace ProjectName.Integration.Tests;

public class AppHostTests
{
    [Fact]
    public async Task AppHost_Starts_Successfully()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.AppHost>();

        await using var app = await appHost.BuildAsync();

        // Act
        await app.StartAsync();

        // Assert
        var httpClient = app.CreateHttpClient("ui");
        var response = await httpClient.GetAsync("/");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        await app.StopAsync();
    }
}
