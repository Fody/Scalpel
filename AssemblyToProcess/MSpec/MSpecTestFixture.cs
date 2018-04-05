using Machine.Specifications;
#pragma warning disable 649
#pragma warning disable 169

public class MSpecTestFixture
{
    It itField = () => classBeingTested.ShouldBeTrue();

    static ClassBeingTested classBeingTested;
    public class ClassBeingTested
    {
        public void ShouldBeTrue()
        {
        }
    }
}