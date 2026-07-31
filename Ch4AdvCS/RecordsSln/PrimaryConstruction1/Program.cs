using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, PrimaryConstruction1!");

        var p1 =new Person("cool_id_69", "cunt", 69);
        WriteLine(p1);

        var p2 = p1 with { id = "cool_id_42" };
        WriteLine(p2);


        var p11 = new PersonStrict("cool_id_6969", "cunt", 69);
        WriteLine(p11);

        //var p22 = p11 with { id = "cool_id_4242" };
        //'PersonStrict.id' is inaccessible due to its protection level

        var p22 = p11 with { name="mate",age=42};

        WriteLine(p22);

    }

}

record Person(string id, string name, int age);
record PersonStrict(string id, string name, int age) 
{
    string id { get; } = id;
};


// [1a] add person record with
// [1b] add primary_cons(id, name, age)
// [1c] add instance
// [1c] add clone instance(with new id)

// [2a] update record: manual property over id
// [2b] removes init
// [2c] add instance
// [2c] add instance with new id: exp fail

