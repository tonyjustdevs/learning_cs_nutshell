using System.Text;
using System.Text.Unicode;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P7_EncodingApp!");

        //string e_string = "é";
        string e_string = "🦖";
        WriteLine($"hex of '{e_string}': ");
        WriteLine($"- utf-8-hxy: {BitConverter.ToString(Encoding.UTF8.GetBytes(e_string))}");
        WriteLine($"- utf-32-hxy: {BitConverter.ToString(Encoding.UTF32.GetBytes(e_string))}");
        WriteLine($"- utf-ascii-hxy: {BitConverter.ToString(Encoding.ASCII.GetBytes(e_string))}");
        //- utf - 8     - hxy: C3 - A9
        //- utf - 32    - hxy: E9 - 00 - 00 - 00
        //- utf - ascii - hxy: 3F

    }
}
