using Xunit;
using Assert = Xunit.Assert;

public partial class WithScalpelConstantTests
{
    [Fact]
    public void NSubstituteIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), x =>x.Name == "NSubstitute");
    }
}