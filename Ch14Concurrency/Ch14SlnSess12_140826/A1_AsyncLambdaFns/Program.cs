using System.Net;
using static System.Console;
partial class Program
{

    public static Dictionary<string, string> _cache_dict = new();

    static async Task Main(string[] args)
    {
        WriteLine("Hello, A1_AsyncLambdaFns!");

        string html; 
        html = await GetWebPgHtml("http://www.example.com");
        
        WriteLine($"html: '{html}'");

        html = await GetWebPgHtml("http://www.example.com");

        WriteLine($"html: '{html}'");

    }

    public static async Task<string> GetWebPgHtml(string uri)
    {
        if (!_cache_dict.TryGetValue(uri, out string? html))
        {
            WriteLine("\n...downloading from web...\n");
            var webpg_html_task = new WebClient().DownloadStringTaskAsync(uri);
            var webpg_html_string = await webpg_html_task;
            _cache_dict.TryAdd(uri, webpg_html_string);
            return webpg_html_string;
        }
        WriteLine("\nretrieving from cache...\n");
        return html;
    }
    // Goal:
    // [1] add dictionary<string,string> _cache_dict
    // [a] - key: uri
    // [b] - val: html

    // [2] check dict for uri (key):
    // [a] - if exists: return html
    // [b] - else: retrieve html

}

