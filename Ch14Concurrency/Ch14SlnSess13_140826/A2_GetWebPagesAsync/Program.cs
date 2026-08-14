using System.Net;
using static System.Console;

internal class Program
{
    static Dictionary<string, string> _cache_html_dct = new();
    static Dictionary<string, Task<string>> _cache_htmltask_dct = new();
    static async Task Main(string[] args)
    {
        WriteLine("Hello, A2_GetWebPagesAsync!");
        //await GetManyWebPages();
        List<Task> tasks = new();
        for (int i = 0; i < 10; i++)
        {
            var task =GetWebPagesHtmlTaskAsync("www.example.com");
            //var task =GetWebPagesHtmlAsync("www.example.com");
            tasks.Add(task);
        }
    }

    // add Dictionary<string, Task<string>>
    public async static Task<string> GetWebPagesHtmlAsync(string uri)
    {
        string? html;
        if (_cache_html_dct.TryGetValue(uri, out html)) 
        {
            WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}] GetWebPagesHtmlAsync(): CACHE-HIT!");
            return html;
        } 
        WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}] GetWebPagesHtmlAsync(): CACHE-MISS! downloading from the web...");
        var task= new WebClient().DownloadStringTaskAsync(uri);
        html = await task;
        _cache_html_dct[uri] = html;
        return html;
    }

    public static Task<string> GetWebPagesHtmlTaskAsync(string uri)
    {
        Task<string>? task;

        lock(_cache_htmltask_dct){
            if (_cache_htmltask_dct.TryGetValue(uri, out task))
            {
                WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}] GetWebPagesHtmlAsync(): CACHE-HIT!");
                return task;
            }
            WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}] GetWebPagesHtmlAsync(): CACHE-MISS! downloading from the web...");
            task = new WebClient().DownloadStringTaskAsync(uri);
            //html = await task;
            _cache_htmltask_dct[uri] = task;
                return task;
        }
    }
}
    //static async Task GetManyWebPages()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        await Task.Run(async () =>
    //        {
    //            WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}] GetManyWebPages()_{i}");
    //            string result;
    //            result = await GetWebPagesHtmlAsync("http://google.com");
    //            WriteLine($"[tid:{Thread.CurrentThread.ManagedThreadId}] length_{i}: {result.Length}");
    //        });
    //    }
    //}
