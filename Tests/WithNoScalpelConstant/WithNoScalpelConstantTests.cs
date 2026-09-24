using Fody;

public class WithNoScalpelConstantTests
{
    [Test]
    public async Task ScalpelIsRemoved()
    {
        var weaver = new ModuleWeaver
        {
            DefineConstants = new()
        };
        var result = weaver.ExecuteTestRun(
            "AssemblyToProcess.dll",
            assemblyName: "WithNoScalpelConstantTests",
            ignoreCodes: ["0x80131869"]);
        var referencedAssemblies = result.Assembly.GetReferencedAssemblies();
        await Assert.That(referencedAssemblies.Any(_ => _.Name == "Scalpel")).IsFalse();
    }
}