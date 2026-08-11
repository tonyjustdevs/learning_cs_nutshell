using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Gday AF2_AA");

        await DisplayPrimeCounts();
        //await DisplayPrimeCounts();

        WriteLine("Main() ends with awaiting");






        async Task DisplayPrimeCounts()
        {
            WriteLine("DisplayPrimeCounts() started");
            for (int i = 0; i < 10; i++)
            {
                var task = GetPrimesCountAsync(i * 1_000_000 + 2, 1_000_000);
                int prime_count = await task;
                WriteLine($"prime_count: {prime_count} (from GetPrimesCountAsync({i * 1_000_000 + 2}, {i * 1_000_000 + 2+1_000_000}))");

            }


            WriteLine("DisplayPrimeCounts() ended");
        }

        Task<int> GetPrimesCountAsync(int start, int count)
        {
            WriteLine("GetPrimesCountAsync() started");
            // a task is created
            // - a threadpool thread runs the logic
            // - task is returned immediately whilst running
            return Task.Run(() =>
              ParallelEnumerable.Range(start, count)
              .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1)
                          .All(i => n % i > 0)
                     ));
        }
    }


    
}
