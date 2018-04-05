using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

class WithScalpelAttributeRemover : IRemover
{
    public IEnumerable<string> GetReferenceNames()
    {
        yield break;
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
        return typeDefinition.CustomAttributes.Any(IsRemoveAttribute);
    }

    static bool IsRemoveAttribute(CustomAttribute y)
    {
        return y.AttributeType.FullName == "Scalpel.RemoveAttribute";
    }
}