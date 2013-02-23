using System.Linq;
using Mono.Cecil;

class XUnitRemover : IRemover
{
    public string ReferenceName
    {
        get { return "xunit"; }
    }

    public bool ShouldRmoveType(TypeDefinition typeDefinition)
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