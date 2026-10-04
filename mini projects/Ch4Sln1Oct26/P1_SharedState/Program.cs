using static System.Console;
namespace P1_SharedState;

internal class Program
{
    public delegate int IntInt_Transformer(int x);
    public static int Square(int x) => x * x;
    public static int Cube(int x) => x * x*x;
    static void Main(string[] args)
    {

        int[] values = { 1, 2, 3 };
        //Transform(values, Square);      // Hook in the Square method
        Transform(values, Cube);      // Hook in the Square method
       
        foreach (int i in values)
            Console.Write(i + "  ");      // 1   4   9
    }

    static int[] Transform(int[] values, IntInt_Transformer t) 
    {
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = t(values[i]);
        }
        return values;
    }

}
