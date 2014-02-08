using System.Collections.Generic;
using Mono.Cecil;

class FakeItEasyRemover : IRemover
{

    public IEnumerable<string> GetReferenceNames()
    {
        yield return "FakeItEasy";
    }

    public IEnumerable<string> GetModuleAttributeNames()
    {
        yield break;
    }

    public IEnumerable<string> GetAssemblyAttributeNames()
    {
        yield break;
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}