using static System.Console;
using System.Globalization;
using System.Text;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, StringHandlingApp!");
        //char c = 'c';
        //char.GetUnicodeCategory();
        WriteLine(Math.Pow(2, 16));
        
        char[] char_array = "gday mate!".ToCharArray();
        WriteLine(char_array.Length);

        foreach (var c in char_array) WriteLine(c);

        var char_string = new string(char_array, 0, 8);
        WriteLine(char_string);

        // strings
        WriteLine("mate vs MAT: {0}",
        "mate".StartsWith("MAT", StringComparison.InvariantCultureIgnoreCase));
        WriteLine("paddings: {0}"," mate ".PadLeft(11, '-').PadRight(16,'-'));

        string composite = "it's {0} degrees in {1} on a {2} evening";
        var s = string.Format(composite, 42, "Ho Chi Minh City", System.DateTime.Now.DayOfWeek);

        WriteLine(s);
    }
}
