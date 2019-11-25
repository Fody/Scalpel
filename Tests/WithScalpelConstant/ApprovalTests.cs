using VerifyXunit;
using Xunit;
using Xunit.Abstractions;

public partial class WithScalpelConstantTests :
    VerifyBase
{
    [Fact]
    public void ApprovalTestsIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), x => x.Name == "ApprovalTests");
    }

    [Fact]
    public void ApprovalUtilitiesIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), x => x.Name == "ApprovalUtilities");
    }

    [Fact]
    public void WithApprovalTestsUseReporterRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "WithApprovalTestsUseReporterAttribute");
    }

    public WithScalpelConstantTests(ITestOutputHelper output) :
        base(output)
    {
    }
}