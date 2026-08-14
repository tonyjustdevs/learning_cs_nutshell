using static System.Console;
using System.Linq;
partial class Program
{

    static async IAsyncEnumerable<int> GetIntDataAsync()
    {
        WriteLine("[gid1] connecting to service...");
        
        await Task.Delay(1000);

        WriteLine("[gid2] receiving external data...");

        int[] ExternalDataArr = new[] { 6, 12, 40, 42, 69, 88, 666 };
        for (int i = 0; i < ExternalDataArr.Length; i++)
        {
            await Task.Delay(1000);
            yield return ExternalDataArr[i];
        }

    }


    static IEnumerable<int> GetIntData()
    {
        return
            from i in Enumerable.Range(0, 10)
            where i % 2 == 0
            select i * 100;

    }


}
