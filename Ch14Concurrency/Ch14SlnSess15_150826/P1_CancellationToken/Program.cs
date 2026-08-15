using static System.Console;
internal class Program
{

    static async Task Main(string[] args)
    {
        WriteLine("Hello, P1_CancellationToken!");
		CancellationTokenSource cts = new CancellationTokenSource(3000);
		try
		{
			await Foo(cts.Token);
		}
		catch (Exception e)
		{
			WriteLine($"Timeout error caught: {e.Message} [{e.GetType()}]");
		}
    }

	static async Task Foo(CancellationToken ctoken)
	{
		while (true)
		{
			await Task.Delay(500, ctoken);
			WriteLine("do some work..."); // does work until 3000 ms timeout
		}
	}
}
