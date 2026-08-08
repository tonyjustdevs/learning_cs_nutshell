using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T6_PrimeContinuationTask!");
        int fro = 2;
        int to  = 3_000_000;

        //int to  = 15; // [2], [3], 4, [5], 6,
                      // [7], 8, 9, 10,[11],
                      // 12,[13],14,15,16

        Task<int>primes_task = Task.Run(() =>
        {
            //bool res;
            var res = Enumerable.Range(fro, to)
                .Count(n => Enumerable.Range(fro, (int)Math.Sqrt(n) - 1) // 2, 3
                .All(i => n % i > 0));
            return res;
        });

        var awaiter = primes_task.GetAwaiter();

        awaiter.OnCompleted(() =>
        {
            var no_of_primes = awaiter.GetResult();
            WriteLine($"number of primes from {fro} to {to}: {no_of_primes}");
        });

        ReadLine();


        // [1] get awaiter() object
        // [2] check isCompleted ??
    }
}
//var res = Enumerable.Range(fro, to)
//    .Count(n => Enumerable.Range(fro, (int)Math.Sqrt(n) - 1) // 2, 3
//    .All(i => n % i > 0));
//WriteLine(res);
