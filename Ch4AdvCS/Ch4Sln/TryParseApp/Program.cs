using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello TryParseApp!!");
        Write("What's your age? ");
        string? input = null!;
        input = ReadLine();
        try
        {
            var result = int.Parse(input);
            WriteLine($"you are {result}");
        }
        catch (Exception e)
        {
            WriteLine($"handled: {e.Message} [{e.GetType()}]");
        }
        //while (true)
        //{
        //    string? input = ReadLine();
        //    if (int.TryParse(input, out int result))
        //    {
        //        WriteLine($"you are {result}");
        //        break;
        //    }
        //    else
        //    {
        //        WriteLine("Please enter age: ");
        //    }
        //}
        WriteLine("program ended");
    }
}
