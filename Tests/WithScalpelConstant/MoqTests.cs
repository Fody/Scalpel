using Xunit;

public partial class WithScalpelConstantTests
{
    [Fact]
    public void MoqIsRemoved()
    {
        var referencedAssemblies = result.Assembly.GetReferencedAssemblies();
        Assert.DoesNotContain(referencedAssemblies, x =>x.Name == "Moq");
    }
}