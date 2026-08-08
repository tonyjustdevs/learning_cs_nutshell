using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T2_ExceptionHandling!");

        try
        {
        // [1] Catch exception via Task.Result
            //var task = Task.Run(() => Go()); // exception is in .Result
            //WriteLine($"task.Result: {task.Result}"); // System.AggregateException
        
            
            // [2] Catch exception via GetAwaiter().GetResult()
            var task2 = Task.Run(() => Go()); // exception is in .Result
            var aw = task2.GetAwaiter();
            
            aw.GetResult();
            //System.AggregateException


        } catch (AggregateException aex)
        {
            WriteLine("aex-caught: {0} [{1}]", aex.Message, aex.GetType());
        }
       
		catch (Exception ex)
		{
            WriteLine("other ex-caught: {0} [{1}]", ex.Message, ex.GetType());
		}

        int Go() => throw null;
        ReadLine();
    }

}
