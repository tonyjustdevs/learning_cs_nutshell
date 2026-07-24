using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday MultiDGApp2!");

        //Transformer<int> t = new(Meth.Squarer);
        int[] arr = [1, 2, 3, 4, 5];
        int[] arr2 = [1, 2, 3, 4, 5];

        WriteLine("arr: {0}", string.Join(" ", arr));
        WriteLine("arr2: {0}", string.Join(" ", arr2));

        Util.TranformTArray(arr, Meth.Squarer);
        Util.TranformTArray2(arr2, Meth.Squarer);

        WriteLine("arr: {0}",string.Join(" ", arr));
        WriteLine("arr2: {0}",string.Join(" ",arr2));
    }
}
delegate T Transformer<T>(T tval);

class Util
{
    public static void TranformTArray<T>(T[] tarr, Transformer<T> t)
    {
        for (int i = 0; i < tarr.Length; i++)
        {
            tarr[i] = t(tarr[i]);
        }
    }
    public static void TranformTArray2<T>(T[] tarr, Func<T,T> t)
    {
        for (int i = 0; i < tarr.Length; i++)
        {
            tarr[i] = t(tarr[i]);
        }
    }
}

class Meth
{
    public static int Squarer(int x) => x * x;
    public static double Doubler(double x) => x * x;
}

