using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        var tid = Thread.CurrentThread.ManagedThreadId;
        WriteLine($"[tid: {tid}] welcome to ap1!");
        await ShowSlowCPUJobsAsync();

        //for (int i = 0; i < 10; i++)
        //{
        //    var awaiter = DoSlowCPUJobAsync(i).GetAwaiter();
        //    awaiter.OnCompleted(() =>
        //    {
        //        WriteLine($"job completed: result{awaiter.GetResult}");
        //    });
        //}
        WriteLine("done");
        async Task ShowSlowCPUJobsAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                //DoSlowCPUJob(i);
                await DoSlowCPUJobAsync(i);
            }
        }
        void DoSlowCPUJob(int job_no)
        {
            var tid = Thread.CurrentThread.ManagedThreadId;
            Write($"[tid: {tid}] Doing [job_{job_no}]...");
            Thread.Sleep(500);
            Write("DONE!\n");
            Thread.Sleep(100);
        }

        Task<int> DoSlowCPUJobAsync(int job_no)
        {
            return Task.Run(async () => 
            {
                var tid = Thread.CurrentThread.ManagedThreadId;
                int op_time = new Random().Next(0, 20)*100;
                WriteLine($"[tid: {tid}] Doing [job_{job_no}] for {op_time} ms...");
                //Thread.Sleep(op_time);
                await Task.Delay(op_time);
                WriteLine($"[tid: {tid}] DONE!");
                await Task.Delay(op_time);
                //Thread.Sleep(500);
                return job_no;
            });

        }
    }

}
