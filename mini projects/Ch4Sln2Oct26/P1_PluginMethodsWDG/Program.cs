using static System.Console;
using static Utils;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, World!");

        int[] values_arr = { 1, 2, 3 };         // receive some data
        Utils.PrintItemsStrIntArr(values_arr);  ////WriteLine(string.Join(', ', values));

        // apply transform-1
        //Utils.Transform1Int(values_arr, Meth.SquareInt);               // ok
        //Utils.Transform1Int(values_arr, Meth.CubeInt);                 // ok  

        // apply transform-2: funcky delegate
        //Utils.Transform2IntFuncky(values_arr, Meth.SquareInt);        // ok  
        //Utils.Transform2IntFuncky(values_arr, Meth.CubeInt);          // ok  

        //// apply transform-3: generic method + generic delegate
        //Utils.Transform3TGeneric(values_arr, Meth.SquareInt);        // ok  
        //Utils.Transform3TGeneric(values_arr, Meth.CubeInt);        // ok  



        //Utils.Transform5ParallelTGeneric(values_arr, Meth.SquareInt);        // ok  

        //Utils.Transform5ParallelTGeneric(values_arr, x=> x * x*x);        // ok  
        Utils.Transform5ParallelTGeneric(values_arr, x=> x +100);        // ok  

        Utils.PrintItemsStrIntArr(values_arr);            // ok

    }
}
class Meth
{
    public static int SquareInt(int x) => x * x;
    public static int CubeInt(int x) => x * x*x;
}

class Utils
{
    public static void PrintItemsStrIntArr(int[] arr) => WriteLine(string.Join(' ', arr));

    public delegate int TransformerInt(int x);
    public delegate T TransformerTT<T>(T x);


    public static void Transform1Int(int[] arr, TransformerInt t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = t(arr[i]);
        }
    }

    public static void Transform2IntFuncky(int[] arr, Func<int,int>t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = t(arr[i]);
        }
    }
    public static void Transform3TGeneric<T>(T[] arr, Func<T, T> t)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = t(arr[i]);
        }
    }
    public static void Transform4TGeneric<T>(T[] arr, TransformerTT<T> transformer)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = transformer(arr[i]);
        }
    }


    public static void Transform5ParallelTGeneric<T>(T[] arr, TransformerTT<T> transformer)
    {

        Parallel.For(0, arr.Length, i =>
        {
            arr[i] = transformer(arr[i]);
        });
    }

}
