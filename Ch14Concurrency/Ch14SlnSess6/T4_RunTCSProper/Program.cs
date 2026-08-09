using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, T4_RunTCSProper!");

        //var task1 = RunSynchronously(CalculateIOLife);
        var task2 = RunAsynchronously(CalculateIOLife);

        //WriteLine("[Case_1_Async]: didnt wait for task, so ends right now...");
        WriteLine("[Case_2_Async]: wait for task...");

        WriteLine($"[Case_2_Async]:task2.Status: {task2.Status}");
        task2.Wait();
        WriteLine($"[Case_2_Async]: wait is over...");
        WriteLine($"[Case_2_Async]:task2.Status: {task2.Status}");
        WriteLine($"[Case_2_Async]:task2.Result: {task2.Result}");

        int CalculateIOLife()
        {                                               // [2a] create int method + simulated i/o delay  ---> int Calculate()
            Thread.Sleep(5000);                         // [2b] + add simulated i/o delay  ---> int Calculate()
            return 69;
        }
        
        // [3a] create Run(Calculate)  ---> returns Task<int>
        Task<int> RunSynchronously(Func<int> int_io_function)
        {
            TaskCompletionSource<int> tcs = new();      // [1]  create tcs_int instance: 
            var task = tcs.Task;
            try                                         // [3b] + add setResult()
            {   
                int int_io_result = int_io_function();
                tcs.SetResult(int_io_result);
                WriteLine($"res_set: {int_io_result}" );
                return task;
            }
            catch (Exception ex)                        // [3c] + add setException()
            {   
                WriteLine($"exc_set: {ex.Message} {ex.GetType()}");
                tcs.SetException(ex);

                return task;
            }
        }

        Task<int> RunAsynchronously(Func<int> int_io_function)
        {

            TaskCompletionSource<int> tcs = new();      // [1]  create tcs_int instance: 
            var task = tcs.Task;

            new Thread(() =>
            {
                try                                         // [3b] + add setResult()
                {
                    int int_io_result = int_io_function();
                    tcs.SetResult(int_io_result);
                    WriteLine($"res_set: {int_io_result}");
                }
                catch (Exception ex)                        // [3c] + add setException()
                {
                    WriteLine($"exc_set: {ex.Message} {ex.GetType()}");
                    tcs.SetException(ex);
                }
            }){ IsBackground = true }.Start();
            
            return task;

        }


    }
}
