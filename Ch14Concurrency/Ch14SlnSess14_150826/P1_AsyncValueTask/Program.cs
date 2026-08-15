using System.Net;
using System.Text.Encodings.Web;
using static System.Console;
internal class Program
{
    static Dictionary<string, string> _html_cache = new();
    static Dictionary<string, Task<string>> _htmltask_cache = new();
    static Dictionary<string, string> _htmlvaluetask_cache = new();
    static async Task Main(string[] args)
    {
        WriteLine("Hello, P1_AsyncValueTask!");
        await Go();
    }
    
    static async Task Go()
    {
        for (int i = 0; i < 10; i++)
        {
            //await GetWebPgHtmlAsync("http://www.example.com");
            //var html_task = GetWebPgHtmlTaskAsync("http://www.example.com");
            var html_valuetask = await GetWebPgHtmlValueTaskAsync("http://www.example.com");
            //WriteLine($"html_task.Id: {html_task.Id}");
            WriteLine($"html_valuetask.length: {html_valuetask.Length}");
        }
    }
    static async ValueTask<string> GetWebPgHtmlValueTaskAsync(string uri)
    {
        string? html;
        //ValueTask<string> html_valuetask;
        if (_htmlvaluetask_cache.TryGetValue(uri, out html))
        {
            WriteLine("cache-hit! got html from cache");
            return html;
        }
        WriteLine("cache-miss! getting html from web");
        html = await new WebClient().DownloadStringTaskAsync(uri);
        _htmlvaluetask_cache[uri] = html; /// add to cache
        return html;
    }
    static Task<string> GetWebPgHtmlTaskAsync(string uri)
    {
        //string? html;
        Task<string>? htmltask;
        if (_htmltask_cache.TryGetValue(uri, out htmltask))
        {
            WriteLine("cache-hit! got html from cache");
            return htmltask;
        }
        //WriteLine("cache-miss! getting html from web");
        htmltask = new WebClient().DownloadStringTaskAsync(uri);
        _htmltask_cache[uri] = htmltask; /// add to cache
        return htmltask;
    }

    static async Task<string> GetWebPgHtmlAsync(string uri)
    {
        string? html;

        if (_html_cache.TryGetValue(uri, out html)) {
            WriteLine("cache-hit! got html from cache");
            return html; }
        WriteLine("cache-miss! getting html from web");
        html = await new WebClient().DownloadStringTaskAsync(uri);
        _html_cache[uri] = html; // add to dictionary
        return html;
    }
}
// [1] dictionary<string, string>