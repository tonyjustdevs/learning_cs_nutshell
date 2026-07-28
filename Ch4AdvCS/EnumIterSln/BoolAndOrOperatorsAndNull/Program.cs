namespace BoolAndOrOperatorsAndNull
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

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
}
