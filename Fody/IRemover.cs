using System.Collections.Generic;
using Mono.Cecil;

interface IRemover
{
    IEnumerable<string> GetReferenceNames();
    bool ShouldRemoveType(TypeDefinition typeDefinition);
}