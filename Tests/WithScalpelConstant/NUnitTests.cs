using Xunit;

public partial class WithScalpelConstantTests
{
    [Fact]
    public void NUnitIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), _ => _.Name == "nunit.framework");
    }

    [Fact]
    public void NUnitTestFixtureIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "NUnitTestFixture");
    }

    [Fact]
    public void WithNUnitIgnoreAttributeRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "WithNUnitIgnoreAttribute");
    }
}