
using static System.Console;
internal class Program
{

    static void Main(string[] args)
    {
        WriteLine("Hello, T3_TaskDelay!");

        var task = Task.Delay(2000).ContinueWith(Action_Task_Method);
        var task2 = Task.Delay(2000).ContinueWith(ant=>WriteLine("i do nothing too...[main()]"));
        ReadLine();
    }

    static void Action_Task_Method(Task task)
    {
        WriteLine("i dont do anything... [Action_Task_Method()]");
    }
}
