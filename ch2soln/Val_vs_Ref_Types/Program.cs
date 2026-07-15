using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("");

        var p1 = new Person { Name = "alice" };

        Person p2 = p1;
        p2.Name = "bob";
        WriteLine($"p1.Name: {p1.Name}");
        WriteLine($"p2.Name: {p2.Name}");
    }
}

public class Person 
{
    public string? Name;
    public Person() { }
};



// 