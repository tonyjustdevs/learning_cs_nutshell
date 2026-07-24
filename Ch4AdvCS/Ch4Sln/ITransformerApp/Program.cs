using System.Threading.Tasks.Dataflow;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("gday ITransformer App");
        //Transformer t=null;
    }


}

delegate int Transformer(int val);