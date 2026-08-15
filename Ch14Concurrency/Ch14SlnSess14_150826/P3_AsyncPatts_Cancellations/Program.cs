using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("[mn_] P3 started!");
        CancellationTokenSource cts = new();

        try
        {
            var downloadtask = DownloadChunksAsync(cts.Token);

            await Task.Delay(2000);
            
            cts.Cancel();

            //await downloadtask;
        }
        catch (OperationCanceledException oce)
        {
            WriteLine($"op_cancel_caught: {oce.Message} [{oce.GetType()}]");
            // op_cancel_caught: A task was canceled. [System.Threading.Tasks.TaskCanceledException]
        }
        catch (Exception e)
        {
            WriteLine($"error_caught: {e.Message}");
        }
        finally
        {

            WriteLine("[mn_] P3 ending!");
        }
        
        
    }

    static async Task DownloadChunksAsync(CancellationToken ctoken)
    {
        for (int i = 0; i < 10; i++)
        {
            var task = Task.Delay(400, ctoken);
            await task;

            //ctoken.throw
            WriteLine($"chunk_{i} downloaded");
        }
    }
}
