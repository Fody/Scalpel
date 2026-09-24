public partial class WithScalpelConstantTests
{
    [Test]
    public async Task FakeItEasyIsRemoved() =>
        await Assert.That(result.Assembly.GetReferencedAssemblies().Any(_ => _.Name == "FakeItEasy")).IsFalse();
}