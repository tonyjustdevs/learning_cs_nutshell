using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("hi, P12_MemoryStream!");

        HttpClient hc = new HttpClient();
        //using var stream = await hc.GetStreamAsync("https://www.google.com/");
        using var stream = await hc.GetStreamAsync("https://www.example.com/photo.jpg");

        using MemoryStream ms = new MemoryStream();
        
        stream.CopyTo(ms);

        var end_position = ms.Seek(0, SeekOrigin.End);
        WriteLine(end_position);
    }
}
