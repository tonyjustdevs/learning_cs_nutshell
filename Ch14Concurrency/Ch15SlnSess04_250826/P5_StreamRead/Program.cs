using System.Security.Cryptography;
using System.Text;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("hi, P5_StreamRead");

        
        using (Stream stream = new FileStream("test5.txt", FileMode.Open)) 
        {
            WriteLine("read test5.txt (no encoding)");
            WriteLine($"_ stream.ReadByte(): {stream.ReadByte()} (exp: 116)");
            WriteLine($"_ stream.ReadByte(): {stream.ReadByte()} (exp: 111)");
            WriteLine($"_ stream.ReadByte(): {stream.ReadByte()} (exp: 110)");
            WriteLine($"_ stream.ReadByte(): {stream.ReadByte()} (exp: 121)");
        }

        using (Stream stream = new FileStream("test5utf8.txt", FileMode.Open))
        {
            WriteLine("\nread test5utf8.txt (utf-8 encoding)");
            WriteLine($"- stream.ReadByte(): {stream.ReadByte()} (exp: 239)");
            WriteLine($"- stream.ReadByte(): {stream.ReadByte()} (exp: 187)");
            WriteLine($"- stream.ReadByte(): {stream.ReadByte()} (exp: 191)");
        }

        //WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 116)");
        //WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 111)");
        //WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 110)");
        //WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 121)");


        //stream.ReadByte(): 239(exp: 116)
        //stream.ReadByte(): 187(exp: 111)
        //stream.ReadByte(): 191(exp: 110)
        //stream.ReadByte(): 116(exp: 121)
    }
}
