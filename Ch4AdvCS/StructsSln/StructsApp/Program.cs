using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        //WriteLine("Hello, StructsApp!");
        //Point point = new Point(42, 69);
        //ShowX(ref new Car(ref point).pt);
        WriteLine(new Plane().Wings);
        
    }
    static void ShowX(ref Point pt) => WriteLine(pt.X);
}

class Car
{
    public Point pt;

    public Car(ref Point pt)
    {
        this.pt = pt;
    }
}
struct Point 
{
    public Point(decimal x, decimal y)
    {
        X = x;
        Y = y;
    }

    public decimal X { get; set; }
    public decimal Y { get; set; }

    public readonly void XChanger(decimal x)
    {
        WriteLine(X);
        //X = 5;
    }
}

// Parameter ref struct: force stack 

class Plane
{
    public int Wings = 4;

    public Plane()
    {
    }
}

class WebOptions
{
    string? _protocol;
    public string? Protocol {
        get
        {
            if (_protocol is null)
            {
                return "http";
            }
            else
            {
                return _protocol;
            }
        }
    }
    public string? Protocol2
    {
        get => _protocol ?? "http";
        set => _protocol = value;
    }





}