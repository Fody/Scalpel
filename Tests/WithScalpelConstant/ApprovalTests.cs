public partial class WithScalpelConstantTests
{
    [Fact]
    public void ApprovalTestsIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), _ => _.Name == "ApprovalTests");

    [Fact]
    public void ApprovalUtilitiesIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), _ => _.Name == "ApprovalUtilities");

    [Fact]
    public void WithApprovalTestsUseReporterRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "WithApprovalTestsUseReporterAttribute");
}