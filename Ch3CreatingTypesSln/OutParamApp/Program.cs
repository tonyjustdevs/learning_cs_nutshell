using System;
using System.Globalization;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using static System.Console;

namespace OutParamApp;

internal class Program
{
    static bool dosplit = false;
    static void Main(string[] args)
    {
        if (dosplit)
        {
        //WriteLine("Out Param 1");
        //GetSplitdOut("tony cules phung", out string first, out string _);
        //WriteLine(first);
        ////WriteLine(rest);

        }

        var test = new Test();
        test.Main2();
    }

    public static void GetSplitdOut(string name, out string first, out string rest)
    {   
        int i   = name.IndexOf(' ');
        first   = name.Substring(0, i);   
        rest    = name.Substring(i+1);
    }

    public class Test
    {
        public static int x;
        public int cool_value;

        static void Main1() 
        {
            //Foo(out x); // the out param goes -> to 'x' loc
        }

        public void Main2()
        {
            Bar(out cool_value);
        }

        static void Foo(out int y)
        {
            WriteLine(x);                // x is 0
            y = 1;                       // Mutate y
            WriteLine(x);                // x is 1
        }
        public void Bar(out int m)
        {
            WriteLine(cool_value);                // x is 0
            m = 69;                       // Mutate m
            WriteLine(cool_value);                // x is 1
        }

    }
}   // Test.x=0 exists in memory

