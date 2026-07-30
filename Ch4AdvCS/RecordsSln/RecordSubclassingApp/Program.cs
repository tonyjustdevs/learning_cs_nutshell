
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, RecordSubclassingApp!");

        var pointless = new Point(42, 69);

        var triple_point = new Point3D(1, 2, 3); 
        WriteLine(pointless);
        WriteLine(triple_point);


        var pt_rec = new PointRecord(1, 2);
        var pt3d_rec = new Point3dRecord(1, 2,3);

        WriteLine(pt_rec);
        WriteLine(pt3d_rec);
    }
}

class Point3D : Point
{
    public Point3D(int x, int y,int z):base(x,y)
    {
        Z = z;
    }

    public int Z { get; }


}

class Point
{
    // [I] THE CLASS
    // - [1a] add Point class
    // - [1b] add X, Y props
    // - [1c] add Constructor(X,Y)

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}

record PointRecord(double X, double Y);
record Point3dRecord(double X, double Y, double Z): PointRecord(X,Y);

// [II] THE SUB-CLASS
// - [2a] add 3DPoint subclass
// - [2b] add Z prop
// - [2c] add Constructor(x,y,z) -> calls base(x,y)
