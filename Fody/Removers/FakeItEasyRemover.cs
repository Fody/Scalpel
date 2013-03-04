using Mono.Cecil;

class FakeItEasyRemover : IRemover
{
    public string[] ReferenceNames
    {
        get { return new[]{ "FakeItEasy"}; }
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}