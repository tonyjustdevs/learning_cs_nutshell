using System.Diagnostics;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("\nhi, FS2_TestTxtApp2!");

        using Stream stream = new FileStream("test2.txt",FileMode.Create);

        stream.WriteByte(69);
        stream.WriteByte(70);
        stream.WriteByte(71);
        stream.WriteByte(72);
        stream.WriteByte(73);
        stream.WriteByte(10);

        WriteLine("\nwriting to test2.txt...");
        WriteLine("stream.WriteByte(69-73): exp: EFGHI_n");
        WriteLine("- stream.Position: {0} (exp: 6)", stream.Position);
        
        
        WriteLine("\nstream.Write(bytes_arr{97-101}): exp: abcde");
        byte[] bytes_arr = { 97, 98, 99, 100, 101 }; 
        stream.Write(bytes_arr, 0, bytes_arr.Length);
        //WriteLine("{0}", );
        WriteLine("- stream.Position: {0} (exp: 11)", stream.Position);

        WriteLine("\nread from stream to byte array? {0}", stream.Read(bytes_arr, 0, bytes_arr.Length));
        WriteLine("stream.Position: {0} (exp: 11 we at end of stream)", stream.Position);

        WriteLine("- Read 0 bytes as at end of Stream, nothing to read!");
        WriteLine("- Reset Position to 0");
        stream.Position = 0;

        Write("\nold bytes array: ");
        foreach (var b in bytes_arr) Write($"{b} ");
        WriteLine("\n- exp: 97 98 99 100 101 (og array)");
        WriteLine("- read from stream to byte array? {0}", stream.Read(bytes_arr, 0, bytes_arr.Length));
        WriteLine("- stream.Position: {0} (exp: 5)", stream.Position);

        Write("\nnew bytes array: ");
        foreach (var b in bytes_arr) Write($"{b} ");
        WriteLine("\n- exp: 69 70 71 72 73 (bytes read from stream)");

        WriteLine("- read AGAIN byte array? {0}", stream.Read(bytes_arr, 0, bytes_arr.Length));
        WriteLine("- stream.Position: {0} (exp: 10)", stream.Position);

        Write("\nnew bytes array 2: ");
        foreach (var b in bytes_arr) Write($"{b} ");
        WriteLine("\n- exp: 10 97 98 99 100 (bytes read from stream)");

        WriteLine("- read LAST byte array? {0}", stream.Read(bytes_arr, 0, bytes_arr.Length));
        WriteLine("- stream.Position: {0} (exp: 11)", stream.Position);

        Write("\nnew bytes array 3 LAST: ");
        foreach (var b in bytes_arr) Write($"{b} ");
        WriteLine("\n- exp: 101 [97 98 99 100](PREV LOOP BYTE)");



    }
}
