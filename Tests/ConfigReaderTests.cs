using System.Xml.Linq;
using NUnit.Framework;

[TestFixture]
public class ConfigReaderTests
{

    [Test]
    public void IncludeAssembliesNode()
    {
        var xElement = XElement.Parse(@"
<Costura>
    <RemoveReferences>
Foo
Bar
    </RemoveReferences>
</Costura>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ReadConfig();
        Assert.AreEqual("Foo", moduleWeaver.RemoveReferences[0]);
        Assert.AreEqual("Bar", moduleWeaver.RemoveReferences[1]);
    }

    [Test]
    public void IncludeAssembliesAttribute()
    {
        var xElement = XElement.Parse(@"
<Costura RemoveReferences='Foo|Bar'/>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ReadConfig();
        Assert.AreEqual("Foo", moduleWeaver.RemoveReferences[0]);
        Assert.AreEqual("Bar", moduleWeaver.RemoveReferences[1]);
    }

    [Test]
    public void IncludeAssembliesCombined()
    {
        var xElement = XElement.Parse(@"
<Costura  RemoveReferences='Foo'>
    <RemoveReferences>
Bar
    </RemoveReferences>
</Costura>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ReadConfig();
        Assert.AreEqual("Foo", moduleWeaver.RemoveReferences[0]);
        Assert.AreEqual("Bar", moduleWeaver.RemoveReferences[1]);
    }


}