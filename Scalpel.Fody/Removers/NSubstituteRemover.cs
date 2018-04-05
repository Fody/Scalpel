using System.Collections.Generic;
using Mono.Cecil;

class NSubstituteRemover : IRemover
{
    public IEnumerable<string> GetReferenceNames()
    {
        yield return "NSubstitute";
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