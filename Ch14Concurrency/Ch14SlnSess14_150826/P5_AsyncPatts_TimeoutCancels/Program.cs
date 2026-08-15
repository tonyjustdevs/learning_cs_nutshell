using static System.Console;
internal class Program
{
	static async Task Foo(CancellationToken ct) 
	{
		await Task.Delay(3010, ct);
		//ct.ThrowIfCancellationRequested(); 
	}
    static async Task Main(string[] args)
    {
        WriteLine("Hello P5!");

		CancellationTokenSource cts = new(3000);
		try
		{
			await Foo(cts.Token);
        }
		catch (Exception e)
		{
			WriteLine($"error_handled: {e.Message}");
		}
		finally
		{
			WriteLine("goodbye!");
		}
    }
}
