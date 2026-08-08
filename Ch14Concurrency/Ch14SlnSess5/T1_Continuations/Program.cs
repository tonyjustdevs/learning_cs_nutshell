using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T1_Continuations!");
        int from_rng = 2; 
        int to_rng = 3_000_000;
        //  2,  3,  4,  5,  6,  ---> 2,4,6
        //  7,  8,  9, 10, 11,  ---> 8,10
        // 12, 13, 14, 15, 16,  ---> 12,14,16 

        var prime_tasks = Task.Run(() => Enumerable.Range(from_rng, to_rng)
            .Count(n => Enumerable.Range(from_rng, (int)Math.Sqrt(n) - 1)
            .All(i => n % i > 0)));

        var awaiter = prime_tasks.GetAwaiter();
        
        awaiter.OnCompleted(async () =>
        {
            var res = awaiter.GetResult();
            WriteLine($"Prime numbers from {from_rng} to {to_rng}: {res}");
        });
        ReadLine();
    }


}
