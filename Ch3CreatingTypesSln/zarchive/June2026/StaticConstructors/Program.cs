
using static System.IO.Path;
using static System.IO.Directory;
using static System.Console;
namespace StaticConstructors;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("load settings via ini file");
        var config = new Configs();
    }
}

public class Configs
{
    //static readonly Dictionary<string, string> config_dct; 
    static readonly Dictionary<string, string> config_dct = new(); 
    static Configs()
    {
        string? out_dir= GetParent(GetCurrentDirectory())?.FullName ;

        var ini_path = Path.Combine(out_dir, "config.ini");
        // create stream for file
        WriteLine($"out_dir: {out_dir}");
        //WriteLine($"ini_pth: {ini_pth}");
    }
}