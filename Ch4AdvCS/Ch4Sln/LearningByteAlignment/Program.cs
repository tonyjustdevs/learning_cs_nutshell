using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {

        WriteLine("Hello Byte Alignment");
    }
}

class Example
{
    byte A;     // 1 byte
    int B;      // 4 bytes
    double C;   // 8 bytes
}

// 0-0:     A
// 1-3:     padding
// 4-7:     B
// 8-15:    C

