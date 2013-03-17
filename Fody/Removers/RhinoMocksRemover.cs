using System.Collections.Generic;
using Mono.Cecil;

class RhinoMocksRemover : IRemover
{

    public IEnumerable<string> GetReferenceNames()
    {
        yield return "Rhino.Mocks";
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}