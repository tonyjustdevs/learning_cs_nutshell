using static System.Console;
using static System.Net.Mime.MediaTypeNames;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello Struct App 2");

        PointClass pc = new();
        object pcc = pc;
        //object.equa
        PointStrct ps = new();

    }
}

//Imagine Microsoft had written this:

public struct Int32TP
{
    private int m_value;
    // int is 32-bit integer
    // -
    // - struct is a val-type: [Equivalence] via field-by-field value comparisons (rather than object references/addresses?)

    //  32-bit object
    //  +-----------+
    //  |m_value = 5|
    //  +-----------+
    //
    //  what is: int x = 5;

}

class PointClass()
{
    public int a = 1;
    public int b = 1;
}

struct PointStrct()
{
    public int a = 1;
    public int b = 1;
}
