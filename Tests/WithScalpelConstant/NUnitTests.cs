using System.Linq;
using NUnit.Framework;

[TestFixture]
public partial class WithScalpelConstantTests
{
    [Test]
    public void NUnitIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x => x.Name == "nunit.framework"));
    }

    [Test]
    public void NUnitTestFixtureIsRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "NUnitTestFixture"));
    }

    [Test]
    public void WithNUnitIgnoreAttributeRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "WithNUnitIgnoreAttribute"));
    }


}