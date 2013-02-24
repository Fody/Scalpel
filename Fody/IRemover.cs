using Mono.Cecil;

interface IRemover
{
    string ReferenceName { get; }
    bool ShouldRemoveType(TypeDefinition typeDefinition);
}