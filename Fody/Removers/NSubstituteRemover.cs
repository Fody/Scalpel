using System.Collections.Generic;
using Mono.Cecil;

class NSubstituteRemover : IRemover
{
    
    public IEnumerable<string> GetReferenceNames()
    {
        yield return "NSubstitute";
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}