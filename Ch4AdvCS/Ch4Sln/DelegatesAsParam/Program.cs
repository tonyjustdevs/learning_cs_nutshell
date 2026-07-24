using static System.Console;
internal class Program
{
    delegate void DG_UseName(string name);
    static void Main(string[] args)
    {
        WriteLine("Hello DG as Param!");
        DG_UseName say_name_thrice = TripleShouter;
        DoSomethingToName("mate", say_name_thrice); // argument is a specific instance of DG_SayName
    }

    static void TripleShouter(string name)
    {
        for (int i = 0; i < 3; i++)
        {
            WriteLine($"hey {name}.");
        }
    }
    static void DoSomethingToName(string name, DG_UseName dg) 
    {
        dg.Invoke(name);
    }

    
}


// create a void delegate type [dg]: prints something
// create a delegate instance: [dg_instance]
// create a method that takes two params: [int] & [del_type]
// run method with argument: [dg_instance]

