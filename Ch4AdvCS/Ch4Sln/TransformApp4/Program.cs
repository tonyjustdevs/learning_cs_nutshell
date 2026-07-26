using static System.Console;    
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello Transform App 4!");
        int[] arr = { 1, 2, 3 };
        //Utils.Transform2(arr, Meth.Squarer);
        //Utils.Transform3(arr, new Square());
        Utils.Transform3(arr, new Cube());
    }
}

interface ITransformer
{
    int Transform(int x);
}

class Square: ITransformer
{
    public int Transform(int x) => x * x;
}

class Cube: ITransformer
{
    public int Transform(int x) => x * x*x;
}

class Meth
{
    public static int Squarer(int x) => x * x;
}
delegate int DGTransformer(int x);

class Utils 
{
    public static void Transform(int[] arr, DGTransformer t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = t(arr[i]);
        }
        WriteLine(string.Join(" ", arr));
    }

    public static void Transform2(int[] arr, Func<int,int> t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = t(arr[i]);
        }
        WriteLine(string.Join(" ", arr));
    }

    public static void Transform3(int[] arr, ITransformer t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = t.Transform(arr[i]);
        }
        WriteLine(string.Join(" ", arr));
    }


}

