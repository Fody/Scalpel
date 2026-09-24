public partial class WithScalpelConstantTests
{
    [Test]
    public async Task TUnitCoreIsRemoved() =>
        await Assert.That(result.Assembly.GetReferencedAssemblies().Any(_ => _.Name == "TUnit.Core")).IsFalse();

    [Test]
    public async Task TUnitTestIsRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "TUnitTest")).IsFalse();
}
