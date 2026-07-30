using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello ExtensionMethodsApp!");

        //WriteLine(StringHelpers.IsCapitalised("bro"));

        //WriteLine("Bro".IsCapitalised());
        //int[] arr = [3, 6, 9];
        //var first = IEnumerableExtensions.FirstElement(arr);
        //WriteLine($"first: {first}");
        //WriteLine($"arr.F`irst(): {arr.First()}");
        WriteLine("cunt".AddExclamation().AddCaptalise());
        
    }
}

static class StringHelpers
{
    public static bool IsCapitalised(this string s)
    {
        if (string.IsNullOrEmpty(s)) return false;
        
        return char.IsUpper(s[0]);
    }

    public static string AddCaptalise(this string s)
    {
        return char.ToUpper(s[0]) + s.Substring(1);
    }
    
    public static string AddExclamation(this string s)
    {
        return s + '!';

    }
}

static class IEnumerableExtensions
{
    public static T FirstElement<T>(this IEnumerable<T> sequence)
    {
        foreach (T item in sequence)
        {
            return item;
        }
        throw new InvalidOperationException($"{nameof(sequence)} [type: {sequence.GetType()}]");

    }
}
