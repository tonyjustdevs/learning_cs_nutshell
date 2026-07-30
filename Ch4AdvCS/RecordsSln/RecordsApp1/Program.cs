using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, RecordsApp1!");
        var john    = new Person("john", 30);
        var john2   = new Person(john.Name, 31);

        WriteLine($"john==john2: {john == john2}");
        var gary    = new PersonRecord("gary", 32);
        var gary2   = gary with { Age = 32 };
        WriteLine($"gary==gary2: {gary == gary2}");
    }

}

class Person
{
    // [class]
    // 1. add class: +.name +.age
    // 2. add instance: with change in .age
    public Person(string name, int age)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Age = age;
    }

    public string Name { get; init; } = null!;
    public int Age { get; init; }

}

// todo:
record PersonRecord(string Name, int Age);
// [record]
// 1. add record: +.name +.age
// 2. add instance: with{} change in .age


