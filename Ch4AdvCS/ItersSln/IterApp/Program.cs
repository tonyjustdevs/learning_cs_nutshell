using System.Runtime.Versioning;
using static System.Console;
#nullable enable
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello IterApp!");
        int[] arr= [1, 2, 3, 4, 5];
        foreach (var cur_run_total in RunningTotal(arr))
        {
            WriteLine(cur_run_total);
        }
    }

    //static List<int> Fibn(int count)
    static IEnumerable<int> Fibn(int count)
    {
        int prev = 1;
        int curr = 1;
        
        var fibs = new List<int>();

        for (int i = 0; i < count; i++)
        {
            //fibs.Add(prev);
            yield return prev;

            int next = curr + prev;
            prev = curr;
            curr = next;

        }

        //return fibs;
    }

    static IEnumerable<int> CountUp(int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return i;
        }
    }

    static IEnumerable<int> RunningTotal(IEnumerable<int> numbers)
    {
        int curr_sum = 0;
        foreach (var value in numbers)
        {
            curr_sum += value;
            yield return curr_sum;
        }
    }

    static IEnumerable<int> Collatz(int n)    // assume n >= 1
    { 
    }
}

