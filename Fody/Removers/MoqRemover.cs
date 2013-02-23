using Mono.Cecil;

class MoqRemover : IRemover
{
    public string ReferenceName
    {
        get { return "moq"; }
    }

    public bool ShouldRmoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}