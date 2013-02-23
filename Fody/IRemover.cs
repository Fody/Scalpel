using Mono.Cecil;

interface IRemover
{
    string ReferenceName { get; }
    bool ShouldRmoveType(TypeDefinition typeDefinition);
}