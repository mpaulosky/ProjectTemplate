namespace ProjectName.Architecture.Tests;

public class LayerTests
{
    [Fact]
    public void DomainShouldNotReferenceSystemData()
    {
        var result = Types
            .InAssembly(typeof(Domain.AssemblyMarker).Assembly)
            .ShouldNot()
            .HaveDependencyOn("System.Data")
            .GetResult();

        result.IsSuccessful.Should().BeTrue(
            because: "the Domain layer must remain free of infrastructure concerns");
    }

    [Fact]
    public void DomainShouldNotReferenceUI()
    {
        var result = Types
            .InAssembly(typeof(Domain.AssemblyMarker).Assembly)
            .ShouldNot()
            .HaveDependencyOn("UI")
            .GetResult();

        result.IsSuccessful.Should().BeTrue(
            because: "Domain must not depend on the presentation layer");
    }
}
