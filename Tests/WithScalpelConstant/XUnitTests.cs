public partial class WithScalpelConstantTests
{
    [Test]
    public async Task XUnitIsRemoved() =>
        await Assert.That(result.Assembly.GetReferencedAssemblies().Any(_ => _.Name == "xunit")).IsFalse();

    [Test]
    public async Task XUnitTheoryIsRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "XUnitTheory")).IsFalse();

    [Test]
    public async Task XUnitMemberDataIsRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "XUnitMemberData")).IsFalse();

    [Test]
    public async Task XUnitFactIsRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "XUnitFact")).IsFalse();

    [Test]
    public async Task XUnitRunWithIsRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "XUnitRunWith")).IsFalse();
}