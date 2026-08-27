using System.Security.Cryptography;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, P8_ReadLines_WithLINQ!");
        string file_name = "p8.txt";
        var IENUM_contents = File.ReadLines(file_name);

        int char_count = 5;
        var filtered_contents = IENUM_contents.Count(l => l.Length >= char_count);
        WriteLine($"lines >= 5 chars: {filtered_contents} (exp: 3");


        //var contents_array = File.ReadAllLines(file_name);
        //foreach (var item in contents_array)
        //{
        //    WriteLine(item.Length);
        //}
        // goal:
        // - calculate nbr of lines greater than 'n' characters
    }
}
