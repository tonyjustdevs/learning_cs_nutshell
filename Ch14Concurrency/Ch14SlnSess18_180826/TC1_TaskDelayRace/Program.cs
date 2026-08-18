using System.Net;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, TC1_TaskDelayRaces!");

    }
    //static async void GetWebPageTotalSize1(string[] uris) 
    //{
    //    IEnumerable<Task<byte[]>> bytes_task_arr =  
    //    uris.Select(uri => new WebClient().DownloadDataTaskAsync(uri));


    //    IEnumerable<Task<int>> bytes_len_arr2 =
    //    uris.Select(async uri => (await new WebClient().DownloadDataTaskAsync(uri)).Length);
    //    // [1] need to 'await' download to get all bytes
    //    // [2] then we can count bytes
    //    // [3] then return the int

    //}


    static async Task<int> GetWebPageTotalSize1(string[] uris)
    {
        List<Task<byte[]>> task_bytes_list = new();
        foreach (var uri in uris)
        {
            var download_bytes_task = new WebClient().DownloadDataTaskAsync(uri);
            task_bytes_list.Add(download_bytes_task);
        }
        var completed_tasks =Task.WhenAll(task_bytes_list); // an array of byte[]
        var bytes_array = await completed_tasks;
        int total_bytes = bytes_array.Sum(byte_arr => byte_arr.Length);
        return total_bytes;
    }
}
