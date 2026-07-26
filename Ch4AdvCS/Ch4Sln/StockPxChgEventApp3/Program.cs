using System.ComponentModel.DataAnnotations;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("G'day StockPxChgEventApp3!");
        var appl = new Stock("appl");
        appl.PriceChanged += stock_PriceChangeSEP;
        appl.Price = 42;
        appl.PriceChanged -= stock_PriceChangeSEP;
        appl.Price = 69;
        appl.PriceChanged += stock_PriceChangeSEP;
        appl.Price = 420;
        appl.Price = 666;
        appl.PriceChanged = null;
        appl.Price = 777;
    }

    static void stock_PriceChange(decimal oldpx, decimal newpx)
    {
        WriteLine($"stock price change: {oldpx} -> {newpx}");
    }
    static void stock_PriceChangeSEP(object? sender, PriceChangeEventArgs e)
    {
        if (sender is not null)
        {
            WriteLine($"'{((Stock)sender).Name}' price change: {e.Oldpx} -> {e.Newpx}");
        }
    }
}

delegate void PriceChangeEvent(decimal oldpx, decimal newpx);

class Stock
{
    public string Name { get; }

    decimal price;
    public Stock(string stock)
    {
        Name = stock;
    }

    //public PriceChangeEvent? PriceChanged;                    // 0A
    public EventHandler<PriceChangeEventArgs>? PriceChanged;    // 0B

    protected virtual void OnPriceChanged(PriceChangeEventArgs e)
    {
        PriceChanged?.Invoke(this,e);
    }
    public decimal Price {
        get => price;
        set 
        {
            if (price == value) return; // [1] return if no change

            decimal oldpx = price;      // [2] update if change
            price = value;

            if (PriceChanged is null)
            {
                WriteLine("price changed but no subscribers!");
                return;
            }
            //PriceChanged(oldpx, price);                               // [3A] trigger event
            //PriceChanged(this, new PriceChangeEventArgs(oldpx, price));
            OnPriceChanged(new PriceChangeEventArgs(oldpx,price));

        }
    }

}

class PriceChangeEventArgs
{
    public decimal Oldpx;
    public decimal Newpx;

    public PriceChangeEventArgs(decimal oldpx, decimal newpx)
    {
        this.Oldpx = oldpx;
        this.Newpx = newpx;
    }
}

//public class TrackedStock : Stock
//{
//    protected override void OnPriceChanged(PriceChangeEventArgs e)
//    {
//        // Perform logging or tracking BEFORE the event fires
//        LogPriceChange(e.OldPrice, e.NewPrice);

//        // Call the base implementation to ensure subscribers are notified
//        base.OnPriceChanged(e);

//        // Perform logging or tracking AFTER the event fires
//        UpdateAnalytics();
//    }
//}