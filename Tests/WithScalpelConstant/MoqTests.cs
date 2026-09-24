public partial class WithScalpelConstantTests
{
    [Test]
    public async Task MoqIsRemoved()
    {
        var referencedAssemblies = result.Assembly.GetReferencedAssemblies();
        await Assert.That(referencedAssemblies.Any(_ => _.Name == "Moq")).IsFalse();
    }
}