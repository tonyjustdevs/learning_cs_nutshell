using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, RecordStructApp!");

        var immutable = new ImmutableClass();
        //WriteLine($"immutable.ImAProp: {immutable.ImAProp}");
        //WriteLine($"immutable.ImAField: {immutable.ImAField}");

        immutable.ImAProp = new() { a = 69 };
        //immutable.GetOnlyImAProp = new() { a = 69 };

        WriteLine("immutable.ImAProp   :{0}",immutable.ImAProp  );
        WriteLine("immutable.ImAProp.a :{0}", immutable.ImAProp.a);
    }

}

class ImmutableClass
{
    public readonly MutableStruct ReadOnlyImAField;
    public MutableStruct ImAField;

    public MutableStruct GetOnlyImAProp { get; }
    public MutableStruct ImAProp { get; set; }
}

struct MutableStruct { public int a; }

// create a mutable_struct
// create a class
// create a field of mutable_struct that is immutable
// create a prop of mutable_struct that is immutable





// Rules of Mutable Fields/Props
// [1] record -> get; init;
// [2] record struct -> get; set;
// [3] readonly record struct{get}?