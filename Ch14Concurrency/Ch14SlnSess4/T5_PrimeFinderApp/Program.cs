using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T5_PrimeFinderApp!");

        Task<int> primes_task = Task.Run(() => Enumerable.Range(2, 3_000_000)
                        .Count(n => Enumerable
                        .Range(2, (int)Math.Sqrt(n) - 1)
                        .All(i => n % i > 0)));
        WriteLine("primes_task.Result :{0}", primes_task.Result);
        ReadLine();
        
        //var primes = Enumerable.Range(2, 9)
        //                .Count(n => Enumerable
        //                .Range(2,(int)Math.Sqrt(n)-1)
        //                .All(i=>n%i>0));
        // 1. count up math.sqrt
        //WriteLine(primes);
    }
}
