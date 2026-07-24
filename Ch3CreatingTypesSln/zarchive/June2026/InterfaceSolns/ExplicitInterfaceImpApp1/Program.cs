using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("G'day Exp-ITF-Imp-App-1");

        // [1] create two interfaces
        // - [a] void method
        // - [b] int method

        // [2] inherits both ITF's


    }
}

interface ITF1 { void Foo(); }
interface ITF2 { int Foo(); }

class Widget : ITF1, ITF2
{
    void ITF1.Foo()
    {
        throw new NotImplementedException();
    }

    void Foo()
    {
        throw new NotImplementedException();
    }

    int ITF2.Foo()
    {
        throw new NotImplementedException();
    }
}
