using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

class XUnitRemover : IRemover
{
    public IEnumerable<string> GetReferenceNames()
    {
        yield return "xunit";
        yield return "xunit.core";
        yield return "xunit2";
    }

    public IEnumerable<string> GetModuleAttributeNames()
    {
        yield break;
    }

    public IEnumerable<string> GetAssemblyAttributeNames()
    {
        yield return "Xunit.CollectionBehaviorAttribute";
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
        var scope = y.AttributeType.Scope.Name;
        return
            scope is "xunit" or "xunit.core" or "xunit2";
    }

    static bool HasXUnitAttributes(MethodDefinition x)
    {
        return HasXunitAttribute(x.CustomAttributes);
    }
}