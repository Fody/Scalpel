using System.Collections.Generic;
using Mono.Cecil;

class MoqRemover : IRemover
{

    public IEnumerable<string> GetReferenceNames()
    {
        yield return "Moq";
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