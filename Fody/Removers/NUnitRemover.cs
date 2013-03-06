using System.Linq;
using Mono.Cecil;

class NUnitRemover : IRemover
{
    public string[] ReferenceNames
    {
        get { return new[]{ "nunit.framework"}; }
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
		return typeDefinition.CustomAttributes.Any(IsNUnitAttribute);
    }

    static bool IsNUnitAttribute(CustomAttribute y)
    {
        return y.AttributeType.Scope.Name == "NUnit.framework";
    }
}