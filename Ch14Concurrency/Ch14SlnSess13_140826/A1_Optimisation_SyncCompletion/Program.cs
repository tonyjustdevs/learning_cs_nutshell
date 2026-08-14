using System.Net;
using static System.Console;
internal class Program
{
    static Dictionary<string, string> _cache_webpages_dct = new();

    public void string GetWebHtml(string uri)
    {
        //string? html;
        //if (_cache_webpages_dct.TryGetValue(uri, out html)) return html;
        //new WebClient().DownloadDataAsync
        new WebClient().DownloadString("");
    }
    static void Main(string[] args)
    {
        WriteLine("Hello, A1_Optimisation_SyncCompletion!");
    }
}
