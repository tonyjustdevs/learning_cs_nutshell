internal class Program
{
    static void Main(string[] args)
    {

    }
}

class BaseClass
{
    public int X;
    public BaseClass(int x) => X = x;
    public BaseClass() { }
}

class SubClass : BaseClass 
{
    public SubClass(int x) : base(x) { }
}
