using System.Collections;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday Interfaces");

        //var ctdwn = new Countdowner();
        //IEnumerator ctdwn = new Countdowner();

        //while (ctdwn.MoveNext())
        //{
        //    WriteLine($"{ctdwn.Current} ");
        //}
        AnotherClass.GetCountDowner();
    }
}

class Countdowner : IEnumerator{
    static Countdowner()
    {
        WriteLine("Countdown started...");
    }
    private int count = 11;

    public object Current => count;

    public bool MoveNext()
    {
        if (count>0)    // perfect for while loop
        {               // returns after last 0 returned
            count--;
            return true;
        }
        count--;
        return false;

    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
