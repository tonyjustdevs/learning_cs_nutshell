using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T2_ThreadPool2!");

        var task = Task.Run(() => 
        {
            Thread.Sleep(100);
            WriteLine("gday mates from tpool");
        });
        WriteLine($"[1]task.status: {task.Status}"); // Wait`ingToRun
        WriteLine($"[2]task.status: {task.Status}"); // RanToCompletion


        //[1]task.status: WaitingToRun
        //[2]task.status: Running
        //gday mates from tpool

        ReadLine();
    }
}
