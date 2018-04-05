using Xunit;

public partial class WithScalpelConstantTests
{
    [Fact]
    public void NUnitIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), x => x.Name == "nunit.framework");
    }

    [Fact]
    public void NUnitTestFixtureIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "NUnitTestFixture");
    }

    [Fact]
    public void WithNUnitIgnoreAttributeRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "WithNUnitIgnoreAttribute");
    }
}