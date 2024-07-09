using Fody;

public class WithNoScalpelConstantTests
{
    [Fact]
    public void ScalpelIsRemoved()
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
        Assert.DoesNotContain(referencedAssemblies, _ => _.Name == "Scalpel");
    }
}