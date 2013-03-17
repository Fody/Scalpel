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
        return fieldDefinition.FieldType.Scope.Name.StartsWith("Machine.Specifications");
    }

}