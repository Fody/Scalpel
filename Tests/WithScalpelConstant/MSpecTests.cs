public partial class WithScalpelConstantTests
{
    [Test]
    public async Task MSpecRefIsRemoved()
    {
        await Assert.That(result.Assembly.GetReferencedAssemblies().Any(_ => _.Name == "Machine.Specifications")).IsFalse();
        await Assert.That(result.Assembly.GetReferencedAssemblies().Any(_ => _.Name == "Machine.Specifications.Clr4")).IsFalse();
    }

    [Test]
    public async Task MSpecTestFixtureIsRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "MSpecTestFixture")).IsFalse();

    [Test]
    public async Task CleanupAfterEveryContextInAssemblyRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "CleanupAfterEveryContextInAssembly")).IsFalse();

    [Test]
    public async Task AssemblyContextRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "AssemblyContext")).IsFalse();
}