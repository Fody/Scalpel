using Machine.Specifications;

public class MSpecTestFixture
{
    
#pragma warning disable 169
    It itField = () => classBeingTested.ShouldBeTrue();
#pragma warning restore 169
       

    static ClassBeingTested classBeingTested;
    public class ClassBeingTested
    {
        public void ShouldBeTrue()
        {
            
        }
    }
}