using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, EqualityComps1!");
        var pt = new Point2(42, 69) { OtherField = 666 };
        var pt2 = new Point2(42, 69) { OtherField = 888 };

        WriteLine(pt == pt2);
    }
}
// [A] Do NORMAL comparison
// 1. add record Point(X,Y)
// 2. compare two instances

record Point(double X, double Y);

record Point2(double X, double Y) 
{
    double _otherField;

    public double OtherField { get => _otherField; set => _otherField = value; }

    public virtual bool Equals(Point2 other)
    {
        if (other is not null && other.X == X && other.Y == Y) return true;

        return false;
    }
};

record Point3(double X, double Y, double Z) : Point2(X, Y) 
{
    public virtual bool Equals(Point3 other)
    {
        return base.Equals(other) && other.Z == Z ;
    }
};
// [B] Do CUSTOM comparison
// 1. add record Point(X,Y)
// 2. add extra otherField
// 3. custom Equals excluding otherField`