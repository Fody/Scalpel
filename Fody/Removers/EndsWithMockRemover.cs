using System;
using Mono.Cecil;

class EndsWithMockRemover : IRemover
{
    public string ReferenceName
    {
        get { return null; }
    }

    public bool ShouldRmoveType(TypeDefinition typeDefinition)
    {
        return typeDefinition.Name.EndsWith("Mock", StringComparison.Ordinal);
    }

}