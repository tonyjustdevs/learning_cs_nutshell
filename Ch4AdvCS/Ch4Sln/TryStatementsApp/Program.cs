using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("gday Tryhards");
        try
        {
            var y = Calc(0);
            WriteLine(y);

        }
        //catch (DivideByZeroException e)
        //{
        //    WriteLine("brooooo: dont divide by zero bro!");
        //    WriteLine("officially: '{0}' [Type: {1}]", e.Message,e.GetType());
        //}
        //catch (Exception e)
        //{
        //    WriteLine("Unknown Error Caught: '{0}' [Type: {1}]",e.Message,e.GetType());
        //}
        catch
        {
            WriteLine("something went wrong!");
        }
        WriteLine("program ended.");
    }

    static int Calc(int x) => 10/x;
}
