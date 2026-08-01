using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, PolymorphicMethods!");

        new Shape().Draw();                 // draw shape

        new Circle().Draw();                // draw circle
        ((Shape)new Circle()).Draw();       // draw circle
        
        new Circle().Draw2();               // draw2 circle
        ((Shape)new Circle()).Draw2();      // draw2 shape

        new Circle().Draw3();               // draw3 circle
        ((Shape)new Circle()).Draw3();      // draw3 shape

        new Circle().Draw4();               // draw4 circle
        ((Shape)new Circle()).Draw4();      // draw4 shape
        //((Shape)new Circle()).Draw4();      // draw4 shape
    }
}

class Circle : Shape
{
    public override void Draw()
    {
        WriteLine("draw circle");
    }
    public new void Draw2()
    {
        WriteLine("draw2 circle");
    }

    public void Draw3()
    {
        WriteLine("draw3 circle");
    }
    public void Draw4()
    {
        WriteLine("draw4 circle");
    }

}

class Shape
{
    public virtual void Draw()
    {
        WriteLine("draw shape");
    }
    public virtual void Draw2()
    {
        WriteLine("draw2 shape");
    }
    public virtual void Draw3()
    {
        WriteLine("draw3 shape");
    }
    public void Draw4()
    {
        WriteLine("draw4 shape");
    }
}
// tp comments:
// - Shape will be used as base-class
// - Draw() will be [inherited] by sub-class
// - Draw() can be [overriden] due to 'virtual' 
// - Draw() is a [run-time] method due to 'virtual'