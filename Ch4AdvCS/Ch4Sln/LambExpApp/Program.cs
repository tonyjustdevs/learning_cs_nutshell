using System.Diagnostics.Metrics;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday LambdaApp-1!");

        Transformer sqr = x => x * x;
        Func<int, int> sqr2 = x => x * x;
        WriteLine(sqr.GetType());

        Func<string, string, int> totalLength = (s1, s2) =>
        {
            return s1.Length + s2.Length;
        };
        //Bar<int>(x => Foo(x));
        //Bar((int x) => Foo(x));

        var sqr3 = (int x) => x * x;

        var print = (string message = "") => WriteLine(message);
        print();
        print("broskies");

        // 1. captured variables  (aka outer variables, closures)

        int cool_val = 69;

        // 2. create a lambda expression capturing cool_val

        var print_cool_val = () => WriteLine("outer var: {0}",cool_val);
        print_cool_val();

        int factor = 2;
        Func<int, int> multiplier = m => m * factor;
        factor = 10;
        WriteLine(multiplier(5));

        // 3. update captured variable

        int meaning_of_life = 42;
        Func<int> apply_meaning = () =>
        {
            meaning_of_life = 69;
            return meaning_of_life;
        };
        WriteLine(apply_meaning());
        
    }
    
    static void Foo<T>(T x) { } 

    // a gen-meth with 1 param
    
    static void Bar<T>(Action<T> a) { }
    // a gen-meth with 1 param that is a generic delegate
    // - ie it can accept a lambda expression
}

delegate int Transformer(int x);