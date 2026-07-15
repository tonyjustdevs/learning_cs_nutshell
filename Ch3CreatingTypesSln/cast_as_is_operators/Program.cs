using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        // two downcast approaches
        Cat oreo = new Cat() { Name = "oreo", Species = "feline" };
        Animal animal = (Animal)oreo;
        Animal animal2 = new Animal() { Species="mammal"} ;
        //WriteLine();
        WriteLine("animal.Speak: {0}", animal.Speak);
        WriteLine("oreo.Speak: {0}", oreo.Speak);
        var name1 = (animal as Cat)?.Name; // can just be null
        var name2 = ((Cat)animal)?.Name; // throws
        WriteLine("(animal as Cat)?.Name: {0}", name1);
        WriteLine("((Cat)animal)?.Name: {0}", name2);

        // is: test before downcasting
        // where object derives from specified clas

        if (animal is Cat oreo2)
        {
            WriteLine("oreo2.Name: {0}", oreo2.Name);

        }


    }
}

public class Animal
{
    public required string Species;
    public virtual string Speak => "default animal sounds";


}

public class Cat : Animal
{
    public string? Name;
    public string? MakeSound => "meows";
    public override string Speak 
    {   
        get{
            return $"{MakeSound} + [base: {base.Speak}]";
        }
    }
}

