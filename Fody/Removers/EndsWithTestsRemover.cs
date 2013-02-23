using System;
using Mono.Cecil;

class EndsWithTestsRemover : IRemover
{
    public string ReferenceName
    {
        get { return null; }
    }

    public bool ShouldRmoveType(TypeDefinition typeDefinition)
    {
        return typeDefinition.Name.EndsWith("Tests",StringComparison.Ordinal);
    }

}