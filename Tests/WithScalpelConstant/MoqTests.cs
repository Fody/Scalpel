using System.Linq;
using NUnit.Framework;

[TestFixture]
public partial class WithScalpelConstantTests
{

    [Test]
    public void MoqIsRemoved()
    {
        var referencedAssemblies = assembly.GetReferencedAssemblies();
        Assert.IsFalse(referencedAssemblies.Any(x=>x.Name == "Moq"));
    }


}