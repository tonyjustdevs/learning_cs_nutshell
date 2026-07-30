using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, Records App!");
        var p1 = new Person("john", 30);
        var p2 = new Person("john", 30);
        WriteLine(p1.Equals(p2));

        var p3 = new PersonRecord("john", 31);
        var p4 = new PersonRecord("john", 31);
        WriteLine(p3.Equals(p4));
    }
}

class Person(string name, int age)
{
    public string Name { get; } = name;
    public int Age { get; } = age;
}

record PersonRecord(string name, int age);
