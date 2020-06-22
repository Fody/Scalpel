using System.Xml.Linq;
using Xunit;

public class ConfigReaderTests
{
    [Fact]
    public void RemoveReferencesNode()
    {
        var xElement = XElement.Parse(@"
<Scalpel>
    <RemoveReferences>
Foo
Bar
    </RemoveReferences>
</Scalpel>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ReadConfig();
        Assert.Equal("Foo", moduleWeaver.RemoveReferences[0]);
        Assert.Equal("Bar", moduleWeaver.RemoveReferences[1]);
    }

    [Fact]
    public void RemoveReferencesAttribute()
    {
        var xElement = XElement.Parse(@"
<Scalpel RemoveReferences='Foo|Bar'/>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ReadConfig();
        Assert.Equal("Foo", moduleWeaver.RemoveReferences[0]);
        Assert.Equal("Bar", moduleWeaver.RemoveReferences[1]);
    }

    [Fact]
    public void RemoveReferencesCombined()
    {
        var xElement = XElement.Parse(@"
<Scalpel RemoveReferences='Foo'>
    <RemoveReferences>
Bar
    </RemoveReferences>
</Scalpel>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ReadConfig();
        Assert.Equal("Foo", moduleWeaver.RemoveReferences[0]);
        Assert.Equal("Bar", moduleWeaver.RemoveReferences[1]);
    }
}