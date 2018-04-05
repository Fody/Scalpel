using System.Collections.Generic;
using Mono.Cecil;

class RhinoMocksRemover : IRemover
{
    public IEnumerable<string> GetReferenceNames()
    {
        yield return "Rhino.Mocks";
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