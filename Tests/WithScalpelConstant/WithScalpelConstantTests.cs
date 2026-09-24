using Fody;
using TestResult = Fody.TestResult;

public partial class WithScalpelConstantTests
{
    static TestResult result;

    static WithScalpelConstantTests()
    {
        var weaver = new ModuleWeaver
        {
            DefineConstants = ["Scalpel"]
        };
        result = weaver.ExecuteTestRun("AssemblyToProcess.dll", assemblyName: "WithScalpelConstantTests");
    }

    [Test]
    public async Task ScalpelIsRemoved() =>
        await Assert.That(result.Assembly.GetReferencedAssemblies().Any(_ => _.Name == "Scalpel")).IsFalse();

    [Test]
    public async Task ClassEndingInMockIsRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "ClassEndingInMock")).IsFalse();

    [Test]
    public async Task ClassEndingInTestsIsRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "ClassEndingInTests")).IsFalse();

    [Test]
    public async Task NestedClassEndingInTests() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "NestedClassEndingInTests")).IsFalse();

    [Test]
    public async Task MarkedWithAttributeIsRemoved() =>
        await Assert.That(result.Assembly.GetTypes().Any(_ => _.Name == "AlsoRemoveMe")).IsFalse();
}