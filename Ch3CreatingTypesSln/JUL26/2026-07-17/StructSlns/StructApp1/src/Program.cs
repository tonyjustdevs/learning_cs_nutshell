
using static System.Console;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("G'day Struct App1 ");
        
        // Point[] points = new Point[1_000_000];
        // Point[] points = new Point[3];
        // PointStruct p1 = new PointStruct(){a=1, b=1};
        // WriteLine(p1.a);
        // WriteLine(p1.b);
        PointStruct p1 = new();
        PointStruct p2 = default;
        WriteLine("p1a{0}, p1a{1}",p1.a,p1.b);
        WriteLine("p2a{0}, p2a{1}",p2.a,p2.b);
    }
}



struct PointStruct
{
    public int a=1;
    public int b;

    public PointStruct()
    {
        b=1;
    }
}
