using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, VitualIntefaceMembersImp!");

        // what does virtual mean?
        // - it means allowed to be overriden?

        new Printer().Print();
        ((Printer)new ColourPrinter()).Print();
        ((Printer)new JapaneseColourPrinter()).Print();

    }

}

class Printer
{
    public virtual void Print() => WriteLine("Printing printing...");
}

class JapaneseColourPrinter : ColourPrinter
{
    public override void Print() => WriteLine("JapaneseColorPrinting printing...");
}
class ColourPrinter : Printer
{
    public override void Print() => WriteLine("ColorPrinting printing...");
}

