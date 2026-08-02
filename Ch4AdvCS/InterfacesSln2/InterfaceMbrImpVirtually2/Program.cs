using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, InterfaceMbrImpVirtually2!");

        new BasedLoggedRichTextbook().Undo();
    }

}

interface IUndoable { void Undo(); }
class Textbook : IUndoable
{
    public virtual void Undo()
    {
        WriteLine("Undo() by Textbook");
    }
}

class RichTextbook : Textbook
{
    public override void Undo()
    {
        WriteLine("Undo() by RichTextbook");
        base.Undo();
    }
}

class LoggedRichTextbook : RichTextbook
{
    public override void Undo()
    {
        WriteLine("'I am watching everything!' by LoggedRichTextbook");
        WriteLine("Undo() by LoggedRichTextbook");
        base.Undo();
    }
}


class BasedLoggedRichTextbook : Textbook
{
    public override void Undo()
    {
        WriteLine("'I am watching everything!' by BasedLoggedRichTextbook");
        WriteLine("Undo() by BasedLoggedRichTextbook");
        base.Undo();
    }
}