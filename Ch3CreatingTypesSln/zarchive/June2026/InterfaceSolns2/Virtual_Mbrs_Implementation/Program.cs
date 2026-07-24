using System.Buffers.Text;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello virutal app");

        //new ConquererClass().Foo(); // conq foo
        //((BaseClass)new ConquererClass()).Foo(); // conq foo

        new HiderClass().Foo(); // conq foo
        ((BaseClass)new HiderClass()).Foo(); // base foo

        var h = new HiderClass(); // conq foo
        BaseClass b = h;
        h.Foo();
        b.Foo();

    }
}   

public class BaseClass
{
    public virtual void Foo() => WriteLine("BaseCase foo!");
}

public class ConquererClass : BaseClass
{
    public override void Foo() => WriteLine("Conquerer foo!");
}

public class HiderClass : BaseClass
{
    public new void Foo() => WriteLine("Hider foo!");
}

