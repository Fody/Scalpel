using System;
using Mono.Cecil;

class EndsWithTestsRemover : IRemover
{
    public string[] ReferenceNames
    {
        get { return new string[]{}; }
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return typeDefinition.Name.EndsWith("Tests",StringComparison.Ordinal);
    }

}