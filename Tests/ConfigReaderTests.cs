using System.Xml.Linq;

public class ConfigReaderTests
{
    [Fact]
    public void RemoveReferencesNode()
    {
        var xElement = XElement.Parse(
            """

            <Scalpel>
                <RemoveReferences>
            Foo
            Bar
                </RemoveReferences>
            </Scalpel>
            """);
        var weaver = new ModuleWeaver { Config = xElement };
        weaver.ReadConfig();
        Assert.Equal("Foo", weaver.RemoveReferences[0]);
        Assert.Equal("Bar", weaver.RemoveReferences[1]);
    }

    [Fact]
    public void RemoveReferencesAttribute()
    {
        var xElement = XElement.Parse(
            """

            <Scalpel RemoveReferences='Foo|Bar'/>
            """);
        var weaver = new ModuleWeaver { Config = xElement };
        weaver.ReadConfig();
        Assert.Equal("Foo", weaver.RemoveReferences[0]);
        Assert.Equal("Bar", weaver.RemoveReferences[1]);
    }

    [Fact]
    public void RemoveReferencesCombined()
    {
        var xElement = XElement.Parse(
            """

            <Scalpel RemoveReferences='Foo'>
                <RemoveReferences>
            Bar
                </RemoveReferences>
            </Scalpel>
            """);
        var weaver = new ModuleWeaver { Config = xElement };
        weaver.ReadConfig();
        Assert.Equal("Foo", weaver.RemoveReferences[0]);
        Assert.Equal("Bar", weaver.RemoveReferences[1]);
    }
}