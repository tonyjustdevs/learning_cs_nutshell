using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, BinaryCompatibilityApp!");
        var foo1 = new Foo(42, 69);
        var foo2 = new Foo(42, 69) { OptionalProp1=888, OptionalProp2=666 };


        WriteLine(foo1);
        WriteLine(foo2);
    }
}

record Foo
{
    public Foo(int requiredProp1, int requiredProp2)
    {
        RequiredProp1 = requiredProp1;
        RequiredProp2 = requiredProp2;
    }

    public int RequiredProp1 { get; init; }
    public int RequiredProp2 { get; init; }

    public int OptionalProp1 { get; init; }
    public int OptionalProp2 { get; init; }

}


// todo:
// [1a] add record
// [1b] add 2 req-props
// [1c] add constructor with 2 req-params
// [1d] add instantiation_v1

// [2a] add 2 optional-props
// [2a] add instantiation_v2
