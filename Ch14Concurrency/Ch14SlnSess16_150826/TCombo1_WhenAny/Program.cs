using static System.Console;    
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("Hello, TCombo1_WhenAny!");

        // [1] add 3 tasks

        async Task<int> task_int1(){ await Task.Delay(1000); return 1; };
        async Task<int> task_int2(){ await Task.Delay(2000); return 2; };
        async Task<int> task_int3(){ await Task.Delay(3000); return 3; };

        // [2] apply task.whenany
        var task_when_any = Task.WhenAny(task_int1(), task_int2(), task_int3());
        var task_winner = await task_when_any;
        var task_result = await task_winner;

        WriteLine($"\ntask_winner_result: {task_result}");
        // [3] get winning task

        // [4] get result
    }
}
