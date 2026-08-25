
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, P6_StreamWrite!");

        //using (Stream stream = new FileStream("test6.txt",FileMode.Open)) 
        //{
        //    WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 116)");
        //    WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 111)");
        //    WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 110)");
        //    WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 121)");
        //};

        //using (Stream stream = new FileStream("test6utf8.txt", FileMode.Open))
        //{
        //    WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 239)");
        //    WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 239)");
        //    WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 239)");
        //    WriteLine($"stream.ReadByte(): {stream.ReadByte()} (exp: 121)");
        //};

        using (Stream stream = new FileStream("test6utfhm.txt", FileMode.Open))
        {   WriteLine("\nfirst bytes of test6utfhm.txt:");
            WriteLine($"- stream.ReadByte(): {stream.ReadByte()} (exp: ? )"); // 255 ---> FF
            WriteLine($"- stream.ReadByte(): {stream.ReadByte()} (exp: ? )"); // 254 ---> FE  // AKA UTF-32 BOM
            WriteLine($"- stream.ReadByte(): {stream.ReadByte()} (exp: ? )"); // 0
            WriteLine($"- stream.ReadByte(): {stream.ReadByte()} (exp: ? )"); // 0


        }
        ;


    }
}
