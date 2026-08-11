using System.Collections;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, AF3_AA!");

        DisplayPrimesCount1();

        void DisplayPrimesCount1()
        {
            WriteLine("Primes between: ");
            for (int i = 0; i < 10; i++)
            {
                WriteLine($"{GetPrimesCount(i * 1_000_000 + 2, 1_000_000)}");
            }
        }

        int GetPrimesCount(int start, int count)
        {
            return Enumerable.Range(start, count)
            .Count(n =>
            {
                bool primes_bool = Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0);
                return primes_bool;
            });
        }
    }


    // get_primes_count

}

class TPTools
{
    public static void DisplayPrimesCount1()
    {
        WriteLine("Primes between: ");
        for (int i = 0; i < 10; i++)
        {
            WriteLine($"{GetPrimesCount(i * 1_000_000 + 2, 1_000_000)}");
        }
    }

    public static void DisplayPrimesCountBad() 
    {
        WriteLine("Primes between: ");
        int fro;
        int increment = 1_000_000;
        for (int i = 0; i < 10; i++)
        {
            fro = i * 1_000_000 + 2;

            int curr_primes_count = GetPrimesCount2(fro, increment);

            WriteLine($"[{fro}-{fro + increment}]: {curr_primes_count}");
        }
    }
    public static int GetPrimesCount(int start, int count)
    {
        return Enumerable.Range(start, count)
        .Count(n =>
        {
            bool primes_bool = Enumerable.Range(start, (int)Math.Sqrt(n) - 1).All(i => n % i > 0);
            return primes_bool;
        });
    }

    public static int GetPrimesCount2(int start, int count)
    {
        return Enumerable.Range(start, count)
        .Count(n => Enumerable.Range(start, (int)Math.Sqrt(n) - 1)
        .All(i => n % i > 0));
    }
    public static IEnumerable<int> GetPrimesRng(int start, int count)
    {
        return Enumerable.Range(start, count).Where(n =>
        {
            var primes_rng = Enumerable.Range(start, (int)Math.Sqrt(n) - 1).All(i => n % i > 0);
            return primes_rng;
        });
    }
}