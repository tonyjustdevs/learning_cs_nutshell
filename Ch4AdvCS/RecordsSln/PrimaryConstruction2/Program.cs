using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, PrimaryConstruction2!");
        var p1 = new Person("mate1");
        WriteLine(p1);

        var p11 = p1 with { Name="mate11"};
        WriteLine(p11);

        var p2 = new Person1("mate2");
        WriteLine(p2);

        //var p22 = p2 with { Name = "mate22" };
        //WriteLine(p22);

        var p3 = new Person2(null);
        WriteLine(p3);

        var p4 = new Person3(null);
        WriteLine(p4);

    }
}

record Person(string Name);
// - this creates Name property: get;init;
// - so Name can be set via
// - [1a] Person() constructor or
// - [1b] via with {Name="..."};

record Person1(string Name) 
{
    //string _name = Name;
    public string Name { get; } = Name;
};

record Person2(string? Name)
{
    string? _name = Name;
    public string? Name 
    { 
        get=>_name; 
        init 
        {
            if (value is null)
            {
                throw new ArgumentException("cant be null", nameof(value));
            }
        } 
    }
}

record Person3
{
    string _name;

    public Person3(string name)
    {
        Name = name;
    }

    public string Name 
    { 
        get => _name; 
        init {
            if (value is null)
            {
                throw new ArgumentException("cant be null",nameof(value)); }
                _name = value;
            }
    }
}

// [1a] add cls with prim_cons(Name)
// [1b] add cls2 with overrided custom Name prop
// [1c] add init validation

// [2a] add show cls2 instance skips init validation

// [3a] add cls3 with normal constructor to trigger init
// [3b] add cls3 instance triggers init
