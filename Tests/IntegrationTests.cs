using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using NUnit.Framework;

[TestFixture]
public class IntegrationTests
{
    Assembly assembly;
    string beforeAssemblyPath;
    string afterAssemblyPath;

    public IntegrationTests()
    {

        beforeAssemblyPath = Path.GetFullPath(@"..\..\..\AssemblyToProcess\bin\Debug\AssemblyToProcess.dll");
#if (!DEBUG)

        beforeAssemblyPath = beforeAssemblyPath.Replace("Debug", "Release");
#endif

        afterAssemblyPath = beforeAssemblyPath.Replace(".dll", "2.dll");
        File.Copy(beforeAssemblyPath, afterAssemblyPath, true);

        var moduleDefinition = ModuleDefinition.ReadModule(afterAssemblyPath);
        var weavingTask = new ModuleWeaver
        {
            ModuleDefinition = moduleDefinition,
            DefineConstants = new List<string> {"Scalpel"}
        };

        weavingTask.Execute();
        moduleDefinition.Write(afterAssemblyPath);

        assembly = Assembly.LoadFile(afterAssemblyPath);
    }


    [Test]
    public void MoqIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x=>x.Name == "Moq"));
    }

    [Test]
    public void FakeItEasyIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x => x.Name == "FakeItEasy"));
    }

    [Test]
    public void MSpecIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x => x.Name == "Machine.Specifications"));
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x => x.Name == "Machine.Specifications.Clr4"));
    }

    [Test]
    public void NSubstituteIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x=>x.Name == "NSubstitute"));
    }
    [Test]
    public void ScalepelIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x=>x.Name == "Scalpel"));
    }

    [Test]
    public void RhinoMocksIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x=>x.Name == "Rhino.Mocks"));
    }

    [Test]
    public void XUnitIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x=>x.Name == "xunit"));
    }
    [Test]
    public void NUnitIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x=>x.Name == "nunit.framework"));
    }
    [Test]
    public void ClassEndingInMockIsRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "ClassEndingInMock"));
    }
    [Test]
    public void ClassEndingInTestsIsRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "ClassEndingInTests"));
    }

    [Test]
    public void NUnitTestFixtureIsRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "NUnitTestFixture"));
    }

    [Test]
    public void MarkedWithAttributeIsRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "AlsoRemoveMe"));
    }
    [Test]
    public void XUnitTestFixtureIsRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "XUnitTestFixture"));
    }
    [Test]
    public void MSpecTestFixtureIsRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "MSpecTestFixture"));
    }

    
#if(DEBUG)
    [Test]
    public void PeVerify()
    {
        Verifier.Verify(beforeAssemblyPath,afterAssemblyPath);
    }
#endif

}