using System.Linq;
using NUnit.Framework;

[TestFixture]
public partial class WithScalpelConstantTests
{
    [Test]
    public void NSubstituteIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x=>x.Name == "NSubstitute"));
    }

}