namespace ProjectName.Architecture.Tests;

public class LayerTests
{
    [Fact]
    public void Domain_Should_Not_Reference_SystemData()
    {
        var result = Types
            .InAssembly(typeof(ProjectName.Domain.AssemblyMarker).Assembly)
            .ShouldNot()
            .HaveDependencyOn("System.Data")
            .GetResult();

        result.IsSuccessful.Should().BeTrue(
            because: "the Domain layer must remain free of infrastructure concerns");
    }

    [Fact]
    public void Domain_Should_Not_Reference_UI()
    {
        var result = Types
            .InAssembly(typeof(ProjectName.Domain.AssemblyMarker).Assembly)
            .ShouldNot()
            .HaveDependencyOn("UI")
            .GetResult();

        result.IsSuccessful.Should().BeTrue(
            because: "Domain must not depend on the presentation layer");
    }
}
