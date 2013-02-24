using System.Linq;
using Mono.Cecil;

class WithScalpelAttributeRemover : IRemover
{
    
    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return typeDefinition.CustomAttributes.Any(IsRemoveAttribute);
    }

    public bool ShouldRemoveReference(string reference)
    {
        return reference == "Scalpel";
    }

    static bool IsRemoveAttribute(CustomAttribute y)
    {
        return y.AttributeType.FullName == "Scalpel.RemoveAttribute";
    }

    public string ReferenceName { get { return "Scalpel"; } }
}