using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, ExplicitInterfaceImplementation!");
        Widget widget = new();
        widget.Foo();
        ((I1)widget).Foo();
        ((I2)widget).Foo();
    }
}
public class Widget : I1, I2
{
    public void Foo()
    {
        WriteLine("Widgets imp of I1.Foo()");
    }

    int I2.Foo()
    {
        WriteLine("Widgets imp of I2.Foo()");
        return 0;
    }
}
interface I1 { void Foo(); }
interface I2 { int Foo(); }

