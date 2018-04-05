using System.Collections.Generic;
using Fody;
using Xunit;

public class WithNoScalpelConstantTests
{
    [Fact]
    public void ScalpelIsRemoved()
    {
        var weavingTask = new ModuleWeaver
        {
            DefineConstants = new List<string>()
        };
        var result = weavingTask.ExecuteTestRun(
            "AssemblyToProcess.dll",
            assemblyName: "WithNoScalpelConstantTests",
            ignoreCodes: new[] {"0x80131869"});
        var referencedAssemblies = result.Assembly.GetReferencedAssemblies();
        Assert.DoesNotContain(referencedAssemblies, x => x.Name == "Scalpel");
    }
}