using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        Func<Task> PrintBarLambdaAsync = async () =>
        {
            await Task.Delay(1000);
            WriteLine("async-bar!");

        };
        WriteLine("Hello, AA2_AsyncLambdas!");

        await PrintBarLambdaAsync();


        //Func<int> GetLifeLambda = () => 42;

        Func<Task<int>> GetLifeLambdaAsync = async () =>
        {
            await Task.Delay(1000);
            return 42;  
        };
        

        //async Task GetLifeAsync()
        //{
        //    await Task.Delay(1000);
        //    Console.WriteLine("foo!");
        //}
    }
}
