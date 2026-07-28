using System.Data.SqlTypes;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday Finally");

        StreamReader? reader = null;
        try
        {
            reader = File.OpenText("myfile.txt");
            if (reader.EndOfStream) return;
            WriteLine(reader.ReadToEnd());
        }
        finally
        {
            WriteLine("finally:");
            if (reader is not null) 
            { 
                WriteLine("finally: disposing reader");
                reader.Dispose();
            } 
        }
    }

}



