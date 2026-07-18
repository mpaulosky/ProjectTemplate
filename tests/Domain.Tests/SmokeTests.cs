namespace Domain.Tests;

using FluentAssertions;

public class SmokeTests
{
	[Fact]
	public void DomainTestProjectIsConfigured()
	{
		// Arrange
		bool value = true;

		// Act

		// Assert
		value.Should().BeTrue();
	}
}
