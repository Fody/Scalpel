using Xunit;

public partial class WithScalpelConstantTests
{
    [Fact]
    public void FakeItEasyIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), x => x.Name == "FakeItEasy");
    }
}