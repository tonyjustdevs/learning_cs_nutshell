using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, P9_AppBaseDirectory!");
        
        WriteLine($"\n\nbase dir: {AppDomain.CurrentDomain.BaseDirectory}");

        string file_name = "p9.txt";

        try
        {
            using (var fs = new FileStream(file_name,FileMode.Truncate)) 
            {
                WriteLine($"\n\nfs.Length: {fs.Length} exp: 0 since Truncate");
            
            }

        }
        catch (Exception ex)
        {
            WriteLine($"ERROR HANDLED: {ex.Message} [{ex.GetType()}]");
        }
    }

}
