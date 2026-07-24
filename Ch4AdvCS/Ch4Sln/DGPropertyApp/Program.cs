using System.Reflection;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("DG Property App");
        var test = new Test();
        DGTransformer_intint dg_t = test.Square;

        WriteLine($"dg_t.Target: {dg_t.Target}");
        WriteLine($"dg_t.GetMethodInfo(): {dg_t.GetMethodInfo()}");
        //

    }
}

public class Test 
{
    public int Square(int x) => x* x;
}

delegate int DGTransformer_intint(int x);


// add [class]
// add void [instance-method] 
// add void [delegate-type]   
// add del [instance] -> [delegate]