
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, World!");

        Utils.Transform([1, 2, 3], new Squarer());
    }
}
interface ITransformer
{
    int Transform(int x);
}
class Squarer : ITransformer
{
    public int Transform(int x)
    {
        WriteLine(x * x);
        return x * x;
    }
}

class Utils
{
    public static void Transform(int[] arr, ITransformer t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = t.Transform(arr[i]);
        }
    }
}