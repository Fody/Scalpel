using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

class MSpecRemover : IRemover
{

    public IEnumerable<string> GetReferenceNames()
    {
        yield return "Machine.Specifications";
        yield return "Machine.Specifications.Clr4";
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
        return ContainsMSpecField(typeDefinition) ||
               typeDefinition.Implements("Machine.Specifications.IAssemblyContext") ||
               typeDefinition.Implements("Machine.Specifications.ICleanupAfterEveryContextInAssembly") ||
               typeDefinition.Implements("Machine.Specifications.ISupplementSpecificationResults");
    }

    static bool ContainsMSpecField(TypeDefinition typeDefinition)
    {
        return typeDefinition.Fields.Any(IsMspecField);
    }

    static bool IsMspecField(FieldDefinition fieldDefinition)
    {
        var scope = fieldDefinition.FieldType.Scope;
        if (scope == null)
        {
            return false;
        }
        return scope.Name.StartsWith("Machine.Specifications");
    }
}