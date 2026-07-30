using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, CalcFieldsLazyEval!");

    }
}

class Point
{

    double Y { get; init; }
    double X { get; init; }

    double? _distance;
    double? DistFromOG {
        get => _distance ; 
        init 
        {
            if (value is null)
            {
                _distance = Math.Sqrt(Y * Y + X * X);
                return;
            }
            _distance = value;
        } 
    }
    public Point(double y, double x)
    {
        (Y,X,DistFromOG) = (y,x,Math.Sqrt(x * x + y + y));
    }

}

// [1] add Point class
// [2] add props: read-only X, Y, DistanceFromOg
// [3] add Constructor sets props