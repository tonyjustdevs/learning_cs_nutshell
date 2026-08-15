using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, P2_ProgressReporting!");

        await Foo(ShowProgressPercent);

        void ShowProgressPercent(int percent)
        {
            Write($"{percent}% complete\n");
        }
    }

    static Task Foo(Action<int> OnProgressPercent)
    {
        return Task.Run(async () => 
        {
            for (int i = 0; i <= 10; i++)
            {
                WriteLine($"\nrunning task_{i}...");
                await Task.Delay(300);
                OnProgressPercent.Invoke(i*10);
                await Task.Delay(300);
            }
        });
    }
}

// [1] add Foo(Action<int> OnProgressPercent)
// [2] add call OnProgressPercent() per iteration ??