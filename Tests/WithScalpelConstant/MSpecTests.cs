using Xunit;

public partial class WithScalpelConstantTests
{
    [Fact]
    public void MSpecRefIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), _ => _.Name == "Machine.Specifications");
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), _ => _.Name == "Machine.Specifications.Clr4");
    }

    [Fact]
    public void MSpecTestFixtureIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "MSpecTestFixture");
    }

    [Fact]
    public void CleanupAfterEveryContextInAssemblyRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "CleanupAfterEveryContextInAssembly");
    }

    [Fact]
    public void AssemblyContextRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "AssemblyContext");
    }
}