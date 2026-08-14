using static System.Console;
partial class Program
{
    static Func<Task<IEnumerable<int>>> DG_GetArrDataAsync = async () =>
    {
        WriteLine("[dg_1] getting data...");
        await Task.Delay(1000);
        WriteLine("[dg_2] data is ready!");
        return new[] { 6, 12, 42, 69, 88 };
    };

    static async Task PrintArrData()
    {
        WriteLine("[pd_1] entered Print...");
        //var array_task = GetArrDataAsync();
        var array_task = DG_GetArrDataAsync();
        var arr_data = await array_task;
        WriteLine(string.Join(" ", arr_data));
        WriteLine("[pd_2] leaving Print...");
    }

    static async Task<IEnumerable<int>> GetArrDataAsync()
    {
        WriteLine("[gd_1] getting data...");
        await Task.Delay(1000);
        WriteLine("[gd_2] data is ready!");
        return new[] { 6, 12, 42, 69, 88 };
    }
    static async IAsyncEnumerable<int> GetArrDataIEAsync()
    {
        WriteLine($"[gx_1][{Thread.CurrentThread.ManagedThreadId}]: Connecting to external data source asyncly...");
        await Task.Delay(1000);
        WriteLine($"[gx_2][{Thread.CurrentThread.ManagedThreadId}]: Connected! Downloading data...");
        int[] SomeExternalData = new[] { 6, 12, 42, 69, 88 };
        for (int i = 0; i < SomeExternalData.Length; i++)
        {
            await Task.Delay(1000);
            WriteLine($"[gx_3][{Thread.CurrentThread.ManagedThreadId}]: {SomeExternalData[i]}");
            yield return SomeExternalData[i];
        }
    }
}
