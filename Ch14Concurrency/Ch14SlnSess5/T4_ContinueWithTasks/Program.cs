using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T4_ContinueWithTasks!");

        var task1 = Task.Run(() => CalculateLife());

        var task2 = task1.ContinueWith(prev_task1 =>
        {
            return prev_task1.Result;
        });

        task2.ContinueWith(prev_task2 => 
        WriteLine($"answer to life is: {prev_task2.Result}"));

        ReadLine();
        int CalculateLife() => 42;
    }


}
