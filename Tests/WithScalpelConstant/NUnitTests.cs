public partial class WithScalpelConstantTests
{
    [Test]
    public async Task NUnitIsRemoved() =>
        await Assert.That(result.Assembly.GetReferencedAssemblies().Any(_ => _.Name == "nunit.framework")).IsFalse();

    [Test]
    public async Task NUnitTestFixtureIsRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "NUnitTestFixture")).IsFalse();

    [Test]
    public async Task WithNUnitIgnoreAttributeRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "WithNUnitIgnoreAttribute")).IsFalse();
}