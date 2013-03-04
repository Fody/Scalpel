using Mono.Cecil;

class NSubstituteRemover : IRemover
{
    public string[] ReferenceNames
    {
        get { return new[] {"NSubstitute"}; }
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}