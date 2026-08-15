using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, P5_ProgressClass!");
        Action<int> ShowProgressPercent = i => WriteLine($"{i}% completed");
        Progress<int> progress = new Progress<int>(ShowProgressPercent);

        await DoHardJob(progress);
        // accepts Action<int> handler --->
        // - Method with 1 'int' argument &
        // - retrusn void
    }
    // add async task

    static Task DoHardJob(IProgress<int> progress)
    {
        return Task.Run(() =>
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(300);
                progress.Report(i*10);
            }
        });
    }
}

class CustomProgressClass : Progress<int>
{
    protected override void OnReport(int value)
    {
        
        base.OnReport(value);
    }
}
// -------------------------- //
// progress class
//public Progress()
//public Progress(Action<T> handler);
//public event EventHandler<T>? ProgressChanged;
//protected virtual void OnReport(T value);