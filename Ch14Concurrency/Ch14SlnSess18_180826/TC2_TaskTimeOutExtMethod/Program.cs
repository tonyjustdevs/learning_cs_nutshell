using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, TC2_TaskTimeOutExtMethod!");
    }

}
static class TonysExtensions { 
    public static async Task<TResult> TimeOut<TResult>(this Task<TResult> task,TimeSpan timeout)
    {
        var task_winner = await Task.WhenAny(task, Task.Delay(timeout)).ConfigureAwait(false);
        if (task_winner!=task) 
        {
            throw new TimeoutException("you snooze you lose!");
        }
        //return await task.ConfigureAwait(false) ;

        if (task==task_winner)
        {
            return await task_winner ;

        }
    }
}