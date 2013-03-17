using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using NUnit.Framework;

[TestFixture]
public partial class IntegrationTests
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
        AssemblyName[] referencedAssemblies = assembly.GetReferencedAssemblies();
        Assert.IsFalse(referencedAssemblies.Any(x=>x.Name == "Moq"));
    }

    [Test]
    public void FakeItEasyIsRemoved()
    {
        Assert.IsFalse(assembly.GetReferencedAssemblies().Any(x => x.Name == "FakeItEasy"));
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
    public void NestedClassEndingInTests()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "NestedClassEndingInTests"));
    }


    [Test]
    public void MarkedWithAttributeIsRemoved()
    {
        Assert.IsFalse(assembly.GetTypes().Any(x => x.Name == "AlsoRemoveMe"));
    }
    
#if(DEBUG)
    [Test]
    public void PeVerify()
    {
        Verifier.Verify(beforeAssemblyPath,afterAssemblyPath);
    }
#endif

}