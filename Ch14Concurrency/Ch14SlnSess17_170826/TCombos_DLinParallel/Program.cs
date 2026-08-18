using System.Net;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, TCombos_DLinParallel!");
        
    }

    static async Task<int> GetTotalSize3(string[] uris)
    {
        IEnumerable<Task<byte[]>> task_list;

        foreach (string uri in uris)
        {
            var task_bytes = new WebClient().DownloadDataTaskAsync();
            // [1] start downloading bytes right now
            // [2] return task_bytes represending download
            // [3] once complete, update task.status to completed
            task_list.Add(task_bytes);
        }

        var tasks_combined = Task.WhenAll(task_list);
        // [1] all tasks are running in parallel on different tpool-threads

        byte[][] tasks = await tasks_combined;
        tasks.Sum(bytes_array => bytes_array.Length);
    }
    static async Task<int> GetTotalSize2(string[] uris)
    {
        List<Task<byte[]>> task_list = new();

        foreach (string uri in uris)
        {
            var task_bytes = new WebClient().DownloadDataTaskAsync();
            // [1] start downloading bytes right now
            // [2] return task_bytes represending download
            // [3] once complete, update task.status to completed
            task_list.Add(task_bytes);
        }

        var tasks_combined = Task.WhenAll(task_list);
        // [1] all tasks are running in parallel on different tpool-threads
        
        byte[][] tasks = await tasks_combined;
        tasks.Sum(bytes_array =>bytes_array.Length);
    }

    static async Task<int> GetTotalSize1(string[] uris)
    {
        List<Task<string>> tasks_list = new();
        foreach (var uri in uris)
        {
            var webpage_string_task = new WebClient().DownloadStringTaskAsync(uri);
            tasks_list.Add(webpage_string_task);
        }
    
        var tasks_combined = Task.WhenAll(tasks_list);
        var webpages_str_list = await tasks_combined;

        int wp_total=0;
        foreach (var wp_str in webpages_str_list)
        {
            wp_total += wp_str.Length;
        }
        return wp_total;
        // what do we want
        // tasks = Task.WhenAll(task1, task2, ...)
        // where task1... are Task<int>

        // so await tasks 
        // tasks = int[]{t1.result, t1.result, ...}
    }
}
