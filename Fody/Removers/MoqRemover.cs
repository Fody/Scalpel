using Mono.Cecil;

class MoqRemover : IRemover
{
    public string ReferenceName
    {
        get { return "moq"; }
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}