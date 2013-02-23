using Mono.Cecil;

class NSubstituteRemover : IRemover
{
    public string ReferenceName
    {
        get { return "NSubstitute"; }
    }

    public bool ShouldRmoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}