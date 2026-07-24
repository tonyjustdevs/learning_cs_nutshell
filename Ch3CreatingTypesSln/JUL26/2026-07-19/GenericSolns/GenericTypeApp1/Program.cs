using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    
    {
        if (false)
        {
            WriteLine("Hello Types App!");
            int x = 42;
            int y = 69;

            string str_a = "bitch";
            string str_b = "slap";


            WriteLine("\npre-swap");
            //WriteLine($"- x:{x}, y:{y}");
            WriteLine($"- str_a:{str_a}, str_b:{str_b}");
        
            //Swapper(ref x, ref y);
            SwapperGeneric(ref str_a, ref str_b);
        
            WriteLine("\npst-swap");
            //WriteLine($"- x:{x}/, y:{y}");
            WriteLine($"- str_a:{str_a}, str_b:{str_b}");

        }

        if (false)
        {
            TPStack<int> stk = new();
            stk.push(42);
            stk.push(69);
            //WriteLine($"{stk._stack}");
            //stk._stack
            var stk_str = string.Join(',', stk._stack[..stk.position]);
            WriteLine(stk_str);
            stk.pop();
            stk_str = string.Join(',', stk._stack[..stk.position]);
            WriteLine(stk_str);

        }
        //WriteLine($"typeof(int): {typeof(int)}");

        var box = new Box<int>();
        //WriteLine(box);
        var openTemplate = typeof(Box<>);
        var clseTemplate = typeof(Box<string>);
        WriteLine(openTemplate);
        WriteLine(clseTemplate);
    }
    public class TPStack<T>
    {
        // some value to increment
        //public List<T> _stack = new();
        public T[] _stack = new T[1000];
        public int position=0;
        public void push(T value) {
            _stack[position++] = value;
        }
        public T pop() => _stack[--position];
    }

    public static void Swapper(ref int a, ref int b)
    {
        int tmp;
        tmp = a;
        a = b;
        b = tmp;
    }

    public static void SwapperGeneric<T>(ref T a, ref T b)
    {
        T tmp;
        tmp = a;
        a = b;
        b = tmp;

    }

    public struct Nullabe<Tony>
    {
        public Tony Value { get; }
    }

    public struct Nullabe2<T>
    {
        public T Value { get; }
    }

    public struct Nullabe3<GT>
    {
        public GT Value { get; }
    }
   
    public class Box<T>
    {
        public T Value { get; set; }
    }
}


