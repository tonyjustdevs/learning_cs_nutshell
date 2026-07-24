using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("G'day Transform App!");
        int[] arr = { 1, 2, 3  };
        Transform(arr, Square);
        WriteLine(string.Join(" ", arr));
        

    }
    delegate int DG_Transformer(int x);
    static void Transform(int[] x, DG_Transformer t)
    {
        for (int i = 0; i < x.Length; i++)
        {
            x[i] = t(x[i]);
        }
    }
    static int Square(int x) => x * x;
}
