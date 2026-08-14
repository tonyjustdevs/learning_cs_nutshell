;using System.Reflection.Metadata;
using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, AF3_AsyncExceptions!");


		try
		{
			var task = Foo();
			await task;
		}
		catch (Exception ex)
		{
			WriteLine($"HandledError: {ex.Message}");
		}


		async Task Foo()
		{
			await Task.Delay(1000);
			throw new Exception();
		}
    }
}
