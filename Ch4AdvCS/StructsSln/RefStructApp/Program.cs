using static System.Console;    

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, Ref Struct App!");

        // [1] (heap) create [arr] of Points 
        // [2] (heap) create [cls] with Point field 

        List<int> numbers = new List<int>();
        var points_chill = new List<PointChill>();
        //var points_strict = new List<PointStrict>();
    }
}

ref struct PointStrict(decimal X, decimal Y) 
{ 
    public decimal X { get; } = X; 
    public decimal Y { get; } = Y;
};

struct PointChill(decimal X, decimal Y)
{
    public decimal X { get; } = X;
    public decimal Y { get; } = Y;
};

class Map
{
    //public PointStrict pointstrict; // pointchill has no ref, its okay
}