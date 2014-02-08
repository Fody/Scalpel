using System.Collections.Generic;
using Mono.Cecil;

interface IRemover
{
    IEnumerable<string> GetReferenceNames();
    IEnumerable<string> GetModuleAttributeNames();
    IEnumerable<string> GetAssemblyAttributeNames();
    bool ShouldRemoveType(TypeDefinition typeDefinition);
}