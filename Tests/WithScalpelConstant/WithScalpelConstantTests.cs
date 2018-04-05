using System.Collections.Generic;
using Fody;
using Xunit;
#pragma warning disable 618

public partial class WithScalpelConstantTests
{
    static TestResult result;

    static WithScalpelConstantTests()
    {
        var weavingTask = new ModuleWeaver
        {
            DefineConstants = new List<string> { "Scalpel" }
        };
        result = weavingTask.ExecuteTestRun("AssemblyToProcess.dll", assemblyName: "WithScalpelConstantTests");
    }

    [Fact]
    public void ScalpelIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), x =>x.Name == "Scalpel");
    }

    [Fact]
    public void ClassEndingInMockIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "ClassEndingInMock");
    }

    [Fact]
    public void ClassEndingInTestsIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "ClassEndingInTests");
    }

    [Fact]
    public void NestedClassEndingInTests()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "NestedClassEndingInTests");
    }

    [Fact]
    public void MarkedWithAttributeIsRemoved()
    {
        Assert.DoesNotContain(result.Assembly.GetTypes(), x => x.Name == "AlsoRemoveMe");
    }
}