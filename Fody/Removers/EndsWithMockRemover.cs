using System;
using Mono.Cecil;

class EndsWithMockRemover : IRemover
{
    public string[] ReferenceNames
    {
        get { return new string[]{}; }
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return typeDefinition.Name.EndsWith("Mock", StringComparison.Ordinal);
    }

}