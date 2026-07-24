using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday Interface Extensions App");

        // [1]  define itf IUndoable
        // [2]  define itf IRedoable:IUndoable

        
    }
}

public interface IUndoable { void Undo(); }
public interface IRedoable : IUndoable { void Redo(); }

public class IDoThingsThenRegretIt : IRedoable
{
    public void Redo()
    {
        throw new NotImplementedException();
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}