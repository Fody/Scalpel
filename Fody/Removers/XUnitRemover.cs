using System.Linq;
using Mono.Cecil;

class XUnitRemover : IRemover
{
    public string[] ReferenceNames
    {
        get { return new[]{ "xunit"}; }
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return typeDefinition.Methods.Any(HasFactAttribute);
    }

    static bool HasFactAttribute(MethodDefinition x)
    {
        return x.CustomAttributes.Any(IsFactAttribute);
    }

    static bool IsFactAttribute(CustomAttribute y)
    {
        return y.AttributeType.Name == "FactAttribute";
    }
}