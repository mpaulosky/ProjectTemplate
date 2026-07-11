using Aspire.Hosting.Testing;

namespace ProjectName.Integration.Tests;

public class AppHostTests
{
    private static bool HasAspireTools()
    {
        var cliPath = Environment.GetEnvironmentVariable("ASPIRE_DCP_CLI_PATH");
        var dashboardPath = Environment.GetEnvironmentVariable("ASPIRE_DASHBOARD_PATH");

        return !string.IsNullOrWhiteSpace(cliPath)
               && File.Exists(cliPath)
               && !string.IsNullOrWhiteSpace(dashboardPath)
               && Directory.Exists(dashboardPath);
    }

    [Fact]
    public async Task AppHost_Starts_Successfully()
    {
        if (!HasAspireTools())
        {
            return;
        }

        // Arrange
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync(typeof(AppHost.AppHostMarker));

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
