using System.Xml.Linq;
using NUnit.Framework;

[TestFixture]
public class ConfigReaderTests
{

    [Test]
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
        Assert.AreEqual("Foo", moduleWeaver.RemoveReferences[0]);
        Assert.AreEqual("Bar", moduleWeaver.RemoveReferences[1]);
    }

    [Test]
    public void RemoveReferencesAttribute()
    {
        var xElement = XElement.Parse(@"
<Scalpel RemoveReferences='Foo|Bar'/>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ReadConfig();
        Assert.AreEqual("Foo", moduleWeaver.RemoveReferences[0]);
        Assert.AreEqual("Bar", moduleWeaver.RemoveReferences[1]);
    }

    [Test]
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
        Assert.AreEqual("Foo", moduleWeaver.RemoveReferences[0]);
        Assert.AreEqual("Bar", moduleWeaver.RemoveReferences[1]);
    }


}