using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

class TUnitRemover : IRemover
{
    public IEnumerable<string> GetReferenceNames()
    {
        yield return "TUnit.Core";
        yield return "TUnit.Assertions";
        yield return "TUnit.Engine";
    }

    public IEnumerable<string> GetModuleAttributeNames()
    {
        yield break;
    }

    public IEnumerable<string> GetAssemblyAttributeNames()
    {
        yield break;
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition) =>
        HasTUnitAttribute(typeDefinition.CustomAttributes) ||
        typeDefinition.Methods.Any(_ => HasTUnitAttribute(_.CustomAttributes));

    static bool HasTUnitAttribute(IEnumerable<CustomAttribute> customAttributes) =>
        customAttributes.Any(_ => _.AttributeType.Scope.Name is "TUnit.Core" or "TUnit.Assertions" or "TUnit.Engine");
}
