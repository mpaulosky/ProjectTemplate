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
	public async Task AppHostStartsSuccessfully()
	{
		if (!HasAspireTools())
		{
			return;
		}

		using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(2));
		var cancellationToken = cancellationTokenSource.Token;

		// Arrange
		var appHost = await DistributedApplicationTestingBuilder
			.CreateAsync<AppHost.AppHostMarker>(cancellationToken);

		await using var app = await appHost.BuildAsync(cancellationToken);

		// Act
		await app.StartAsync(cancellationToken);

		// Assert
		using var httpClient = app.CreateHttpClient("ui");
		var response = await httpClient.GetAsync(new Uri("/", UriKind.Relative), cancellationToken);

		response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

		await app.StopAsync(cancellationToken);
	}
}
