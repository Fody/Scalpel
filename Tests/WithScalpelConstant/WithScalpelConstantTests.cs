using Fody;

public partial class WithScalpelConstantTests
{
    static TestResult result;

    static WithScalpelConstantTests()
    {
        var weavingTask = new ModuleWeaver
        {
            DefineConstants = ["Scalpel"]
        };
        result = weavingTask.ExecuteTestRun("AssemblyToProcess.dll", assemblyName: "WithScalpelConstantTests");
    }

    [Fact]
    public void ScalpelIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetReferencedAssemblies(), _ => _.Name == "Scalpel");

    [Fact]
    public void ClassEndingInMockIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "ClassEndingInMock");

    [Fact]
    public void ClassEndingInTestsIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "ClassEndingInTests");

    [Fact]
    public void NestedClassEndingInTests() =>
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "NestedClassEndingInTests");

    [Fact]
    public void MarkedWithAttributeIsRemoved() =>
        Assert.DoesNotContain(result.Assembly.GetTypes(), _ => _.Name == "AlsoRemoveMe");
}