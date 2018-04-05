using Xunit;

public partial class WithScalpelConstantTests
{
    [Fact]
    public void XUnitIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), x => x.Name == "xunit");
    }

    [Fact]
    public void XUnitTheoryIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "XUnitTheory");
    }

    [Fact]
    public void XUnitMemberDataIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "XUnitMemberData");
    }


    [Fact]
    public void XUnitFactIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "XUnitFact");
    }

    [Fact]
    public void XUnitRunWithIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "XUnitRunWith");
    }
}