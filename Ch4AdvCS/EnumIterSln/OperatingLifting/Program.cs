using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, Op-Lifting!");

        int? x = 5;
        int? y=null;

        WriteLine($"5+null = {x + y} (exp: null)");
        //if (x>y)
        //{
        //    WriteLine("x>y: true");
        //    return;
        //}
        //WriteLine("x>y: false");

        ComparisonToNull();
    }

    static void ComparisonToNull()
    {
        int? age = null;
        WriteLine($"age < 18: {age < 18} (exp: null)");
        
        
    }

    static void CompExamples()
    {
        int? x = 5;
        int? y = null;

        // Equality operator examples
        Console.WriteLine(x == y);    // exp: false 5==null 
        Console.WriteLine(x == null); // exp: false 5==null
        Console.WriteLine(x == 5);    // exp: true  5==5
        Console.WriteLine(y == null); // exp: true  n==n
        Console.WriteLine(y == 5);    // exp: false null==5
        Console.WriteLine(y != 5);    // exp: true  !null==5

        // Relational operator examples
        Console.WriteLine(x < 6);     // exp: true  5<6
        Console.WriteLine(y < 6);     // exp: false null<6
        Console.WriteLine(y > 6);     // exp: false null>6

        // All other operator examples
        Console.WriteLine(x + 5);     // exp: 10    5+5
        Console.WriteLine(x + y);     // exp: null  5+null
    }

    static void boolAndOrOperators()
    {
        bool? n = null;
        bool? f = false;
        bool? t = true;
        Console.WriteLine($"n | n: {n | n} (exp: )");    // T[t|f], T[t|t], T[f|t], F[f|f]  => NULL
        Console.WriteLine($"n | f: {n | f} (exp: )");    // T[t|f], F[f|f]                  => NULL
        Console.WriteLine($"n | t: {n | t} (exp: )");    // T[t|t], T[f|t]                  => TRUE
        Console.WriteLine($"n & n: {n & n} (exp: )");    // F[t&f], T[t&t], F[f&t], F[f&f]  => NULL
        Console.WriteLine($"n & f: {n & f} (exp: )");    // F[t&f], F[f&f]                  => FALSE
        Console.WriteLine($"n & t: {n & t} (exp: )");    // T[t&t], F[f&t]                  => NULL
    }
}
//ANSWERS
//Console.WriteLine(n | n);    // (null)
//Console.WriteLine(n | f);    // (null)
//Console.WriteLine(n | t);    // True
//Console.WriteLine(n & n);    // (null)
//Console.WriteLine(n & f);    // False
//Console.WriteLine(n & t);    // (null)









