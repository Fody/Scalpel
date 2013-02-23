using Mono.Cecil;

class RhinoMocksRemover : IRemover
{
    public string ReferenceName
    {
        get { return "Rhino.Mocks"; }
    }

    public bool ShouldRmoveType(TypeDefinition typeDefinition)
    {
        return false;
    }

}