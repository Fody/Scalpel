using System.Xml.Linq;

public class ConfigReaderTests
{
    [Test]
    public async Task RemoveReferencesNode()
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
        await Assert.That(weaver.RemoveReferences[0]).IsEqualTo("Foo");
        await Assert.That(weaver.RemoveReferences[1]).IsEqualTo("Bar");
    }

    [Test]
    public async Task RemoveReferencesAttribute()
    {
        var xElement = XElement.Parse(
            """

            <Scalpel RemoveReferences='Foo|Bar'/>
            """);
        var weaver = new ModuleWeaver { Config = xElement };
        weaver.ReadConfig();
        await Assert.That(weaver.RemoveReferences[0]).IsEqualTo("Foo");
        await Assert.That(weaver.RemoveReferences[1]).IsEqualTo("Bar");
    }

    [Test]
    public async Task RemoveReferencesCombined()
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
        await Assert.That(weaver.RemoveReferences[0]).IsEqualTo("Foo");
        await Assert.That(weaver.RemoveReferences[1]).IsEqualTo("Bar");
    }
}