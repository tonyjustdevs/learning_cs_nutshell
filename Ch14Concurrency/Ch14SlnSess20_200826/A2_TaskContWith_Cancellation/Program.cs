using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, A2_TaskContWith_Cancellation!");
        CancellationTokenSource cts = new();
        try
        {
            var task = Foo();
            Task.Delay(4000).ContinueWith(antecedent => cts.Cancel());
            task.Wait(cts.Token);
        }
        catch (Exception ex)
        {
            WriteLine($"{ex.Message}");
        }


        Task Foo() 
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(1000);
                    WriteLine($"{i} processed");
                };
            });
        }
    }

}
