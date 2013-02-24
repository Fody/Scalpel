using Mono.Cecil;

class NSubstituteRemover : IRemover
{
    public string ReferenceName
    {
        get { return "NSubstitute"; }
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}