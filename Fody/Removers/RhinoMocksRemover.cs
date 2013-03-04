using Mono.Cecil;

class RhinoMocksRemover : IRemover
{
    public string[] ReferenceNames
    {
        get { return new[]{ "Rhino.Mocks"}; }
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}