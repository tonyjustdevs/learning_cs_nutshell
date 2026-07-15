using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday Covariant-Return-Types App!");
        mate = new TPAsset(){ Name="mate"};
        Writeline();
    }

}

class TPAsset
{
    public string Name;
    public TPAsset Clone(string name) { Name = name; }
}
