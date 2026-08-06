using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        var work_item = new WorkItem();
        Print(work_item);
    }
    static void Print(object obj)
    {
        WriteLine("Name: {0}",((WorkItem)obj).Name);
        WriteLine("Age: {0}",((WorkItem)obj).Age);
        WriteLine("IsAdm: {0}", ((WorkItem)obj).IsAdmin);
        
    }
}

class WorkItem
{
    public string Name="mate"!;
    public int Age=42;
    public bool IsAdmin=true;
}



