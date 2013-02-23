using System.Linq;
using Mono.Cecil;

class NUnitRemover : IRemover
{
    public string ReferenceName
    {
        get { return "nunit.framework"; }
    }

    public bool ShouldRmoveType(TypeDefinition typeDefinition)
    {
        return typeDefinition.CustomAttributes.Any(IsTestFixtureAttribute);
    }

    static bool IsTestFixtureAttribute(CustomAttribute y)
    {
        return y.AttributeType.Name == "TestFixtureAttribute";
    }
}