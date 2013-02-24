using Mono.Cecil;

class RhinoMocksRemover : IRemover
{
    public string ReferenceName
    {
        get { return "Rhino.Mocks"; }
    }

    public bool ShouldRemoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}