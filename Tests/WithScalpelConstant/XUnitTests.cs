using System.Linq;
using NUnit.Framework;

[TestFixture]
public partial class WithScalpelConstantTests
{

    [Test]
    public void XUnitIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x=>x.Name == "xunit"));
    }
    [Test]
	public void XUnitFactIsRemoved()
    {
		Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "XUnitFact"));
    }

    [Test]
	public void XUnitRunWithIsRemoved()
    {
		Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "XUnitRunWith"));
    }
    

}