using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using static System.Console;
partial class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello ReadTradesIEnumerableApp");

        //// [1] read all into memory
        //string[] trades_array = File.ReadAllLines("trades.csv")[1..];
        //var tradesIE = File.ReadLines("trades.csv");

        string[] tradesArray = File.ReadAllLines("trades.csv");
        var tradesIE = File.ReadLines("trades.csv");

        // object sive

        WriteLine("size(tradesArray): {0}", GetObjectSize(tradesArray));
        WriteLine("size(tradesIE): {0}", GetObjectSize(tradesIE));




    }


    //static int GetObjectSize(object obj)
    //{
    //    if (obj == null) return 0;
    //    try
    //    {
    //        // This gives us the managed object overhead, not the data it points to
    //        unsafe
    //        {
    //            IntPtr ptr = Marshal.AllocHGlobal(sizeof(IntPtr));
    //            Marshal.FreeHGlobal(ptr);
    //        }
    //        // For our purposes, we'll use a simpler approach
    //        return System.Text.Encoding.UTF8.GetByteCount(obj.ToString() ?? "null");
    //    }
    //    catch
    //    {
    //        return 0; // Simplified for demo
    //    }
    //}
`

}
