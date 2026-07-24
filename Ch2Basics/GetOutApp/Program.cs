using System.ComponentModel.DataAnnotations;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("GetOutApp");
        TryParsePayment("99.99 usd", out decimal amt, out string ccy);
        WriteLine("99.99 usd is: ");
        WriteLine($"ccy: {ccy}");
        WriteLine($"amt: {amt}");

    }
    public static bool TryParsePayment(string payment, 
        out decimal amount, out string currency) 
    {   // sample: "99.99 USD"
        amount=0;
        currency = "";

        string[] parts = payment.Split(" ");
        if (parts.Length != 2) return false;

        if (!decimal.TryParse(parts[0], out amount)) return false;
        if (parts[1].Length != 3) return false;
        currency= parts[1].ToUpperInvariant();
        return true;
    
    }

}
