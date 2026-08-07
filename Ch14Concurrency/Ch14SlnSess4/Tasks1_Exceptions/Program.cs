using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, Tasks1_Exceptions!");

        try
        {
            Task<int> task = Task.Run(() => {
                throw null;
                return 69;
            });
            //task.Wait();
            Thread.Sleep(500); // task needs time (to properly fail) don't we all?
            WriteLine("task.IsFaulted: {0}", task.IsFaulted); 
            WriteLine("task.Exception: {0}", task.Exception);
        }
        catch (Exception e)
        {
            WriteLine($"[task error handled]: {e.Message}");
        }


        // create a task
        // - throw null

        // create try-catch
        // - capture task exception
        // - 1. the task itself
        // - 2. task.wait()
    }
}
