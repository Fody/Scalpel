using System.Linq;
using NUnit.Framework;

[TestFixture]
public partial class WithScalpelConstantTests
{

    [Test]
    public void RhinoMocksIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x=>x.Name == "Rhino.Mocks"));
    }

}