
public partial class WithScalpelConstantTests
{
    [Test]
    public async Task NSubstituteIsRemoved() =>
        await Assert.That(result.Assembly.GetReferencedAssemblies().Any(_ => _.Name == "NSubstitute")).IsFalse();
}