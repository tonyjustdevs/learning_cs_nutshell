using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, BaseSubClsConstructors!");

        //var sub69 = new SubCls(69);

        //var doggo = new Dog();


        var car = new Car() { DriveType="asdf"};

        var car2 = new Car("asdf"); 
    }
}

class Car
{
    static void CreateCar() { }
    public required string DriveType;
    public Car() { }
    
    [SetsRequiredMembers]
    public Car(string driveType)
    {
        //DriveType = driveType;
        //CreateCar();
    }
}

class BaseCls
{
    public int X;
    public BaseCls(){}
    public BaseCls(int x)
    {
        WriteLine("BaseCls(int x) constructor called...");
        X = x;
    }
}

class SubCls : BaseCls
{
    public SubCls(int x): base(x)
    {
        WriteLine("SubCls(int x) constructor called...");
    }
}

class Dog : Animal
{
    public Dog() : base("doggoooooooo")
    {
        WriteLine("Dog() called...");
    }
}
class Animal
{
    string _name;
    public Animal(string name) 
    {
        WriteLine("Animal() called...");
        _name = name;
    }
}