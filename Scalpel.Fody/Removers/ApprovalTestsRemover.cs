using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

class ApprovalTestsRemover : IRemover
{
    public IEnumerable<string> GetReferenceNames()
    {
        yield return "ApprovalTests";
        yield return "ApprovalUtilities";
    }

    public IEnumerable<string> GetModuleAttributeNames()
    {
        yield return "ApprovalTests.Reporters.UseReporterAttribute";
    }

    public IEnumerable<string> GetAssemblyAttributeNames()
    {
        yield return "ApprovalTests.Reporters.UseReporterAttribute";
        yield return "ApprovalTests.Reporters.FrontLoadedReporterAttribute";
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return typeDefinition.CustomAttributes.Any(IsApprovalTests);
    }

    static bool IsApprovalTests(CustomAttribute y)
    {
        return y.AttributeType.Scope.Name == "ApprovalTests";
    }
}