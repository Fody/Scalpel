using System.Linq;
using NUnit.Framework;

[TestFixture]
public partial class WithScalpelConstantTests
{

    [Test]
    public void MSpecRefIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x => x.Name == "Machine.Specifications"));
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x => x.Name == "Machine.Specifications.Clr4"));
    }

    [Test]
    public void MSpecTestFixtureIsRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "MSpecTestFixture"));
    }

    [Test]
    public void CleanupAfterEveryContextInAssemblyRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "CleanupAfterEveryContextInAssembly"));
    }

    [Test]
    public void AssemblyContextRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "AssemblyContext"));
    }

}