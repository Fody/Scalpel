using Xunit;

public class XUnitTheory
{
    [Theory]
    [InlineData("data")]
    public void Method(string data)
    {
        Assert.Equal("data",data);
    }
}