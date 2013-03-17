using Machine.Specifications;

public class MSpecTestFixture
{
    
//// ReSharper disable UnusedMember.Local
    It itField = () => classBeingTested.ShouldBeTrue();
//// ReSharper restore UnusedMember.Local
       

    static ClassBeingTested classBeingTested;
    public class ClassBeingTested
    {
        public void ShouldBeTrue()
        {
            
        }
    }
}