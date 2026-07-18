namespace AppHost;

public class SmokeTests
{
	[Fact]
	public void UnitTestProjectIsConfigured()
	{
		// Arrange
		bool value = true;

		// Act

		// Assert
		value.Should().BeTrue();
	}
}
