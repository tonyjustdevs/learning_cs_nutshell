using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P10_ReadOnlyStream!");

        // goal: create a read-only stream

        //using var fs = new FileStream("p10.txt", FileMode.Open, FileAccess.Read);
        //fs.WriteByte(100);

        //var fs2 =  File.OpenRead("p10.txt");
        using var fs2 = new FileStream("p10.txt", FileMode.Append);
        fs2.WriteByte(99);
        fs2.WriteByte(117);
        fs2.WriteByte(110);
        fs2.WriteByte(116);
        fs2.WriteByte(33);
        fs2.WriteByte(13);
        fs2.WriteByte(10);
    }
}
