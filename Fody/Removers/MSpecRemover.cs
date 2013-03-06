using System.Linq;
using Mono.Cecil;

class MSpecRemover : IRemover
{
    static string[] referenceNames = new[] { "Machine.Specifications", "Machine.Specifications.Clr4" };
    public string[] ReferenceNames
    {
        get
        {
            return referenceNames;
        }
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
        var fieldModuleName = fieldDefinition.FieldType.Scope.Name;
        return referenceNames.Any(x => x == fieldModuleName);
    }

}