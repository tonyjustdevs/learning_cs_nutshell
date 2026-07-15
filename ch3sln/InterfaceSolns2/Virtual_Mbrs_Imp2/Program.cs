using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello to Undo-World");
        var r = new RichTextBox();
        WriteLine("new richtxtbook");    
        r.Undo();
        ((TextBox)r).Undo();
        ((IUndoable)r).Undo();

        var t =new TextBox();
        WriteLine("new txtbook");    
        t.Undo();
        ((IUndoable)t).Undo();
    }
}

interface IUndoable
{
    void Undo();
}

class TextBox : IUndoable
{
    virtual public void Undo()
    {
        WriteLine("Textbook Undone!");
    }

    void IUndoable.Undo()
    {
        WriteLine("IUndoable explicit Undo");
    }
}

class RichTextBox : TextBox
{
    public override void Undo()
    {
        WriteLine("RichTextbook undone!!!");
    }
}