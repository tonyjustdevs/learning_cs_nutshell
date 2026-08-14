using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}][mn_1_1] Hello, AA3_AsyncIEnumeration!");

        WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}][mn_2_2] Before GetDataAsync()");
        var data_ienum = await GetDataAsync();
        WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}][mn_3_5] After GetDataAsync()");

        foreach (var item in data_ienum)
        {
            WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}][mn_3_6] {item}");
        }

        async Task<IEnumerable<int>> GetDataAsync()
        {
            WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}][gd_1_3] ");
            await Task.Delay(2000);
            WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}][gd_2_4] ");
            return new[] { 1, 2, 3, 4, 5 };
        }
    }
}
