using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T3_ExcHand_NonGenericTask!");

		try
		{
			var task = Task.Run(() => throw null);
			task.Wait();
		}
		catch (Exception ex)
		{
			WriteLine("ex-caught: {0}", ex.Message);
		}
		ReadLine();
    }
}
