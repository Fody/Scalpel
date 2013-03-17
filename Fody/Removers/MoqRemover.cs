using System.Collections.Generic;
using Mono.Cecil;

class MoqRemover : IRemover
{

    public IEnumerable<string> GetReferenceNames()
    {
        yield return "Moq";
    }


    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}