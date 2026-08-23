using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T4_ExceptionHandling!");

		try
		{
			new Thread(() => {

				try
				{
					WriteLine("goooo!"); 
					throw null;

				}
				catch (Exception ex)
				{
                    WriteLine("[Go()] ex: {0} [{1}]", ex.Message, ex.GetType());
                    throw;
				}
			}).Start();
		}
		catch (Exception ex)
		{
			WriteLine("[Main()] ex: {0} [{1}]", ex.Message, ex.GetType());
		}
    }

}
