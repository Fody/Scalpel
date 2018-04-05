using Machine.Specifications;
#pragma warning disable 169

public class Something
{
    It does_not_matter;

    class Parent
    {
        public Child Child { get; set; }
    }

    class Child
    {
    }
}