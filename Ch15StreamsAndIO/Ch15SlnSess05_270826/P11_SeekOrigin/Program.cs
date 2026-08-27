using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, P11_SeekOrigin!");

        WriteLine(File.ReadAllText("p11.txt").Length);

        using var fs = new FileStream("p11.txt", FileMode.Open);
        
        var curr_pos = fs.Seek(0, SeekOrigin.End);
        WriteLine($"curr_pos: {curr_pos} (after SeekOrigin.End) (A: 42)");

        


    }
}
