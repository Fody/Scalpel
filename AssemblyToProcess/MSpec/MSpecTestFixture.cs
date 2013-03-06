using Machine.Specifications;

public class MSpecTestFixture
{
    
    It itField = () =>
                 classBeingTested.ShouldBeTrue();

    static ClassBeingTested classBeingTested;
    public class ClassBeingTested
    {
        public void ShouldBeTrue()
        {
            
        }
    }
}