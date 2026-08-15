using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, P4_IProgress!");
        await DoExpensiveCpuWorkAsync(new TonysProgressReport());
    }

    class TonysProgressReport : IProgress<int>
    {
        public void Report(int value)
        {
            WriteLine($"{value}% completed...[TonysProgressReport.Report()]");
        }
    }
    public static Task DoExpensiveCpuWorkAsync(IProgress<int> onProgressPercentChanged)
    {
        return Task.Run(() =>
        {
            for (int i = 0; i <= 10; i++)
            {
                WriteLine($"doing work_{i}");
                Thread.Sleep(1000);
                onProgressPercentChanged.Report(i * 10);
            }
        });
    }
}
