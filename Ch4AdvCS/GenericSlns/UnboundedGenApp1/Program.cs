using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday Unbounded App");
        //var a_int = new A<int>();
        //a_int.SomeMethod();
        A<int> a_int_instance = new();
        a_int_instance.PrintTDefaults();

        A<string> a_str_instance = new();
        a_str_instance.PrintTDefaults();

    }
}

class A<T>
{
    public void SomeMethod()
    {
        //var t = typeof(T);
        //WriteLine($"t: {t} [inside: A<T>.SomeMethod()]");

    }

    // 1. apply default(T) to [ref-val]
    // 2. apply default(T) to [ref-val]

    public void PrintTDefaults()
    {
        WriteLine($"\nRunning A<T>.PrintTDefaults():");
        T[] t_array = new T[10];
        foreach (var item in t_array)
        {
            WriteLine($"- {item} ({item?.GetType()})");
        }
    }
}


public class B<T>
{
    public void Zap(T?[] t_array)
    {
        for (int i = 0; i < t_array.Length; i++)
        {
            t_array[i] = default;
            //default()
        }
    }
}

