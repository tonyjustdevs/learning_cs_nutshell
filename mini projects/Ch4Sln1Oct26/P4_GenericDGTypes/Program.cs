using System.Threading.Tasks.Dataflow;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P4!");
        int Square(int x) => x * x;
        int Cube(int x) => x * x*x;

        int[] arr = [1, 2, 3];
        //Util.GenericTransform(arr, Square);
        Util.GenericTransform(arr, Cube);


        for (int i = 0; i < arr.Length; i++)
        {
            WriteLine(arr[i]);

        }
    }


}

public class Util
{
    public delegate T TransformTTDG<T>(T x);
    public static void GenericTransform<T>(T[] arr, TransformTTDG<T> t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = t(arr[i]);
        }
    }
}
