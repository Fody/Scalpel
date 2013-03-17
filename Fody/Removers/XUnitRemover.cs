using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

class XUnitRemover : IRemover
{

    public IEnumerable<string> GetReferenceNames()
    {
        yield return "xunit";
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
		return HasXunitAttribute(typeDefinition.CustomAttributes) || typeDefinition.Methods.Any(HasXUnitAttributes);
    }

	static bool HasXunitAttribute(IEnumerable<CustomAttribute> customAttributes)
	{
		return customAttributes.Any(IsXUnitAttribute);
	}

	static bool IsXUnitAttribute(CustomAttribute y)
	{
		return y.AttributeType.Scope.Name == "XUnit";
	}
    static bool HasXUnitAttributes(MethodDefinition x)
    {
		return HasXunitAttribute(x.CustomAttributes);
    }

}