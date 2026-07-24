using MyTouchyLibrary;
using System.Collections;
using static System.Console;
//namespace MyLibrary;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Welcome to Internal-Getter-1");
        //IEnumerator a_secret_obj = (IEnumerator)InternalClassRevealerCls.GetSecretClass();
        var a_secret_obj = (IEnumerator)InternalClassRevealerCls.GetSecretClass();

        PrintIEnumerableThings(a_secret_obj);
    }
    public static void PrintIEnumerableThings(IEnumerator e)
    {
        while (e.MoveNext())
        {
            WriteLine($"current_value: {e.Current}");
        }
    }
}


