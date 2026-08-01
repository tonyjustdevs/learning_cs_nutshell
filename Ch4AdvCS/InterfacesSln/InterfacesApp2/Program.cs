using System.Reflection.Metadata.Ecma335;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, InterfacesApp2!");

        Cat oreo = new Cat("oreo");
        oreo.Speak();
        WriteLine(oreo.name);

        var oreo_animal = (Animal)oreo;
        oreo_animal.Speak();
        WriteLine(oreo_animal.name);
    }
}

//abstract class Asset
//{
//    public abstract decimal NetValue { get; }
//}

//class Stock : Asset
//{
//    decimal price;
//    int quantity;
//    decimal _netValue;
//    public override decimal NetValue 
//    {
//        get { return price* quantity; }
//        //set { _netValue = value; }
//    } 
//}

// 0. polymorphism
class Animal
{
    public string name = "default animal";
    public virtual void Speak() => WriteLine("i'm an animal!");

    public Animal(string Name)
    {
        name = Name;
    }
}

class Cat : Animal
{
    public new string name = "default cat";
    public Cat(string Name) : base(Name)
    {
    }

    public override void Speak()
    {
        WriteLine("meow... cause im a cat");
        //base.Speak();
    }
}
// 1. abstract members
// 2. Hiding Inherited Members


//public class A { public int Counter=1; }
//public class B:A { public int Counter=2; }