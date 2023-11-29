public partial class WithScalpelConstantTests
{
    [Fact]
    public void XUnitIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), _ => _.Name == "xunit");

    [Fact]
    public void XUnitTheoryIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "XUnitTheory");

    [Fact]
    public void XUnitMemberDataIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "XUnitMemberData");

    [Fact]
    public void XUnitFactIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "XUnitFact");

    [Fact]
    public void XUnitRunWithIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "XUnitRunWith");
}