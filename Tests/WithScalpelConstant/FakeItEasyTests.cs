public partial class WithScalpelConstantTests
{
    [Fact]
    public void FakeItEasyIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), _ => _.Name == "FakeItEasy");
}