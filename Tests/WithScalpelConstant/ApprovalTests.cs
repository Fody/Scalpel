public partial class WithScalpelConstantTests
{
    [Test]
    public async Task ApprovalTestsIsRemoved() =>
        await Assert.That(result.Assembly.GetReferencedAssemblies().Any(_ => _.Name == "ApprovalTests")).IsFalse();

    [Test]
    public async Task ApprovalUtilitiesIsRemoved() =>
        await Assert.That(result.Assembly.GetReferencedAssemblies().Any(_ => _.Name == "ApprovalUtilities")).IsFalse();

    [Test]
    public async Task WithApprovalTestsUseReporterRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "WithApprovalTestsUseReporterAttribute")).IsFalse();
}