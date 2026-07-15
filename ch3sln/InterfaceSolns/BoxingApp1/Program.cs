using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Lets box!");


        int a = 42;
        object a_box = a; // box the int

        //// int the box ?
        //long a_out_of_box = (long)a_box;
        //WriteLine(a_out_of_box);

        //inferred boxing
        object c = 69;
        //long d =(long)c; //  Unable cast object o'Int32' -> 'Int64'.    
        int d =(int)c;
    }
}
