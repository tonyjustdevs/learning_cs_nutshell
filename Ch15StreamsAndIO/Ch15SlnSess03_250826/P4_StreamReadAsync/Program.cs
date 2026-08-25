using System.Security.Cryptography;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P4_StreamReadAsync!");
        //TPReadAsync("test4.txt");
        try
        {
            using (Stream stream = new FileStream("test4.txt", FileMode.Open)) 
            {
                WriteLine("file exists, reading first 4 bytes:");
                byte[] bytes = Array.Empty<byte>();
                WriteLine("sp: {0}",stream.Position);

                WriteLine($"s.ReadByte(): {stream.ReadByte()} exp: 116");
                WriteLine($"s.ReadByte(): {stream.ReadByte()} exp: 111");
                WriteLine($"s.ReadByte(): {stream.ReadByte()} exp: 110");
                WriteLine($"s.ReadByte(): {stream.ReadByte()} exp: 121");

            }

        }
        catch (Exception ex)
        {

            WriteLine("error-caught: file doesnt exist?");
            WriteLine($"{ex.Message} [{ex.GetType()}]");
        }

        WriteLine("end of program");
    }

    public static void TPReadAsync(string txt_file)
    {
        using Stream stream = new FileStream(txt_file, FileMode.Open);
        byte[] bytes = Array.Empty<byte>();
        var bytes_read = stream.Read(bytes,0,bytes.Length);
        WriteLine($"bytes_read: {bytes_read}");
        
        foreach (var b in bytes) WriteLine($"{b} [sp:{stream.Position}]");

        ReadLine();
    }
}
