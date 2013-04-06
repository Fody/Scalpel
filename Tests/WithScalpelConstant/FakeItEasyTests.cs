using System.Linq;
using NUnit.Framework;

[TestFixture]
public partial class WithScalpelConstantTests
{


    [Test]
    public void FakeItEasyIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x => x.Name == "FakeItEasy"));
    }


}