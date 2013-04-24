using System.Linq;
using NUnit.Framework;

[TestFixture]
public partial class WithScalpelConstantTests
{
    [Test]
    public void ApprovalTestsIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x => x.Name == "ApprovalTests"));
    }

    [Test]
    public void WithApprovalTestsUseReporterRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "WithApprovalTestsUseReporterAttribute"));
    }


}