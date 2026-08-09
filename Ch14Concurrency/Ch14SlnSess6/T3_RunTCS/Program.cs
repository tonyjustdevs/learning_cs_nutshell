using System.Text;
using static System.Console;

internal class Program
{
    delegate int int_delegate();
    delegate Task<int> taskint_delegate();
    delegate Task<int> Run();

    static void Main(string[] args)
    {
        WriteLine("Hello, T3_RunTCS!");

        // we want a task to re
        var task = Run(CalculateLife);
        
        Task<int> Run(int_delegate dg)
        {
            Task<int> task = Task.Run(() => 
            {
                return dg.Invoke();
            });
            return task;
        }
        ReadLine();

        int CalculateLife(){ Thread.Sleep(3000); return 42; };


    }
}
