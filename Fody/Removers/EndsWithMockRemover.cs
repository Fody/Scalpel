using System;
using System.Collections.Generic;
using Mono.Cecil;

class EndsWithMockRemover : IRemover
{

    public IEnumerable<string> GetReferenceNames()
    {
        yield break;
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
        return typeDefinition.Name.EndsWith("Mock", StringComparison.Ordinal);
    }

}