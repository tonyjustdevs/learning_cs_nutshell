using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T3_ReturnValues!");

        Task<int> task = Task.Run(() => 
        { 
            WriteLine("sup cunt");
            Thread.Sleep(3000);
            return 69; 
        });
        WriteLine("task is running...");
        WriteLine($"task.Result: {task.Result}");
    }
}
