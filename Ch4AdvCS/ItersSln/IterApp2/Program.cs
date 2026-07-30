using System.Reflection.Emit;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, IterApp2!");

        foreach (var item in Fib_Even_Only(fib(8)))
        {
            WriteLine(item);
        }
    }

    static IEnumerable<int> Fib_Even_Only(IEnumerable<int> sequence)
    {

        foreach (int fib_val in sequence)
        {
            if (fib_val%2==0)
            {
                yield return fib_val;
            }
        }
    }



    static IEnumerable<int> fib(int count)
    {
        int prev = 1;
        int curr = 1;
        // 1,1,3,7,17,41,99,239,
        // 1,1,2,3,5,8,13,21...
        for (int i = 0; i < count; i++)
        {
            yield return prev;

            int next = curr + prev; // 2=1p+1c
            prev = curr;            // 1->1
            curr = next;           // 1->2
            
        }
    }
}



