using System.Threading.Channels;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi P3 price alert system!");
        Stock telsa = new("Telsa");
        telsa.PriceChanged += StockAnalytics.StockPriceChangeTracker;
        telsa.PriceChanged += Tracker.PriceLogger;
        telsa.PriceChanged += Tracker.PriceAlert;
        //telsa.PriceChanged?.Invoke(telsa, new PriceChangeEventArgs(2342343, 8995698790));
        telsa.Price = 105;
        telsa.Price = 112;
    }
}
class StockAnalytics 
{ 
    public static void StockPriceChangeTracker(object? sender, PriceChangeEventArgs e)
    {
        if (sender is Stock s) 
        //if (sender is Stock s && e is PriceChangeEventArgs pce)
        {
            //WriteLine($"\nPrice changed: {pce.oldpx} -> {pce.newpx} [{s.Name}]");
            WriteLine($"\nPrice changed: {e.oldpx} -> {e.newpx} [{s.Name}]");
        }
    }
}
class Tracker
{
    public static void PriceLogger(object? sender, PriceChangeEventArgs e)
    {
        if (sender is Stock s)
        //if (sender is Stock s && e is PriceChangeEventArgs pce)
        {
            WriteLine($"PriceLogger: recording price change...");
        }
    }
    public static void PriceAlert(object? sender, PriceChangeEventArgs e)
    {
        if (sender is Stock s)
        //if (sender is Stock s && e is PriceChangeEventArgs pce)
        {
            if (e.newpx>110)
            {

            WriteLine($"PriceAlert: ALERT! Price exceeded 110 [{s.Name}]");
            }
        }
    }


}

class Stock
{
    decimal price=100;
    string name;
    public string Name => name;
    public Stock(string stock) => this.name = stock;


    public decimal Price
    { 
        get { return price; }

        set
        {
            if (price == value) return;
            decimal oldpx = price;
            price = value;

            OnPriceChanged(new PriceChangeEventArgs(oldpx, price));
        }
    }

    public event EventHandler<PriceChangeEventArgs>? PriceChanged;
    protected virtual void OnPriceChanged(PriceChangeEventArgs e)
    {
        PriceChanged?.Invoke(this, e);
    }
    // add constructor with required name parameter
}

public class PriceChangeEventArgs : EventArgs
{
    public readonly decimal oldpx;
    public readonly decimal newpx;

    public PriceChangeEventArgs(decimal oldpx, decimal newpx)
    {
        this.oldpx = oldpx;
        this.newpx = newpx;
    }
}
