using static System.Console;
internal class Program
{
    delegate int IntInt_Txfr(int x);
    static int Int_Squarer(int x) => x * x;
    static void Main(string[] args)
    {
        //WriteLine("Hello, World!");
        IntInt_Txfr t = Int_Squarer;

        WriteLine($"t: {t}");
        WriteLine($"t.gettype: {t.GetType()}");
        WriteLine($"typeof(IntInt_Txfr): {typeof(IntInt_Txfr)}");

        WriteLine($"t(5): {t(5)}");
        WriteLine($"t.Invoke(5): {t.Invoke(5)}");
    }

}
