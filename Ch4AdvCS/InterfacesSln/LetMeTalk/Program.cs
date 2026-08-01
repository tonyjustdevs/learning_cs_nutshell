using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, LetMeSpeak!");
        var cat = new Cat();
        var dog = new Dog();

        //IEnumerable<Animal> animals = new List<Animal>()
        //{
        //    new Cat(),
        //    new Dog(),
        //    new Cat(),
        //    new Dog(),
        //};

        //Animal.LetMeTalk(animals);
    }
}

class Animal
{
    public virtual void Speak() => WriteLine("im an animal");

    public static void LetMeTalk(IEnumerable<Animal> animals)
    {
        foreach (var animal in animals)
        {
            animal.Speak();
        }
    } 
}

class Cat : AnimalAbstract
//class Cat : Animal
{
    //public override void Speak()=> WriteLine("im cat");
    public override void Speak()=> WriteLine("im cat");
}

class Dog : AnimalAbstract
//class Dog : Animal
{
    public override void Speak() => WriteLine("im dog");
}

abstract class AnimalAbstract
{
    public abstract void Speak();
}