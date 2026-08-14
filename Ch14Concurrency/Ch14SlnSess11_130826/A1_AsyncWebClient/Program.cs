using System.Data;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.Unicode;
using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, A1_AsyncWebClient!");
        try
        {
            await GoGoGoIAE();
        }
        catch (Exception ex)
        {
            WriteLine($"error caught: {0} [{1}]", ex.Message, ex.GetType());
            throw;
        }
    }
    static async Task GoGoGoIAE()
    {

        var get_webpg_iae = GetWebpageBytesIAE();

        await foreach (var webpg_byte_chunk in get_webpg_iae)
        {
            string webpg_string = UTF8Encoding.UTF8.GetString(webpg_byte_chunk);
            WriteLine("webpg_chunk_str: {0}", webpg_string);
        }

    }

    static async IAsyncEnumerable<byte[]> GetWebpageBytesIAE()
    {
        WebClient wclient = new();
        var data_download_task = wclient.DownloadDataTaskAsync("http://www.google.com");
        WriteLine("downloading...");
        
        var data_bytes = await data_download_task;
        WriteLine("got some data...[bytes: {0}]", data_bytes.Length);
        yield return data_bytes;
    }
    static async Task GoGoGo()
    {
        WriteLine("[GG_1_1] started...");

        var get_webpg_task = GetWebpageBytesSglTask();
        WriteLine("[GG_2_5] got sgl task...");

        var webpg_bytes = await get_webpg_task;
        WriteLine("[GG_3_7] got data...[bytes: {0}]", webpg_bytes.Length);

        string webpg_string = UTF8Encoding.UTF8.GetString(webpg_bytes);
        
        WriteLine("[GG_4_8] webpg_string: {0}", webpg_string);
    }


    static async Task<byte[]> GetWebpageBytesSglTask()
    {
        WriteLine("[SG_1_2] started...");

        WebClient wclient = new();
        WriteLine("[SG_2_3] created client...");

        var data_download_task = wclient.DownloadDataTaskAsync("http://www.example.com");
        WriteLine("[SG_3_4] got download task...");
        
        var data_bytes = await data_download_task;
        WriteLine("got data...[bytes: {0}]", data_bytes.Length);
        return data_bytes;
    }

}
