using Mono.Cecil;

interface IRemover
{
    string[] ReferenceNames { get; }
    bool ShouldRemoveType(TypeDefinition typeDefinition);
}