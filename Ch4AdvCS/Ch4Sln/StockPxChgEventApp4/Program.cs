using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday StockApp4");
        var telsa = new Stock("telsa");
        telsa.SubsChanged += OnStockSubsChanged;
        telsa.Price = 42;
        telsa.PriceChanged += OnStockPriceChanged;
        telsa.Price = 69;
        telsa.PriceChanged -= OnStockPriceChanged;
        telsa.PriceChanged += OnStockPriceChanged;
        telsa.Price = 420;
    }

    static void OnStockSubsChanged(object? sender, EventArgs e)
    {
        if (sender is Stock s)
        {
            WriteLine($"{s.Name} has a new")
            s.Name
        }
    } 
    static void OnStockPriceChanged(object? sender, PriceChangeEventArgs e)
    //static void stock_PriceChange(object? sender, PriceChangeEventArgs e)
    {
        //if (sender is not null)
        //{
        //    WriteLine($"{((Stock)sender).Name} price change: {e.oldpx} -> {e.newpx}");
        //}
        if (sender is Stock s)
        {
            WriteLine($"{s.Name} price change: {e.oldpx} -> {e.newpx}");
        }

    }
}
class Stock
{
    string stock;
    public string Name => stock;
    decimal price;
    private EventHandler<PriceChangeEventArgs>? priceChanged;
    public EventHandler SubsChanged;

    protected virtual void OnSubsChanged(System.EventArgs e)
    {
        SubsChanged?.Invoke(this, e);
    }
    public event EventHandler<PriceChangeEventArgs>? PriceChanged 
    {
        add
        {
            priceChanged += value;

            OnSubsChanged(EventArgs.Empty);
            //WriteLine($"[subs] new sub: {value?.Method.Name}");
        }
        remove
        {
            priceChanged -= value;
            OnSubsChanged(EventArgs.Empty);
            //WriteLine($"[subs] unsubbed: {value?.Method.Name}");
        }
    }


    public Stock(string stock)
    {
        this.stock = stock;
    }

    protected virtual void OnPriceChanged(PriceChangeEventArgs e)
    {
        if (priceChanged is null)
        {
            WriteLine("price changed but no subcribers!!!");
            return;
        }
        priceChanged.Invoke(this, e);
    }
    public decimal Price
    {
        get => price;
        set
        {
            if (price == value) return;
            decimal oldpx = price;
            price = value;
            OnPriceChanged(new PriceChangeEventArgs(oldpx,price));
        }
    }
}
sealed class PriceChangeEventArgs : System.EventArgs
{
    public decimal oldpx { get; }
    public decimal newpx { get; }

    public PriceChangeEventArgs(decimal oldpx, decimal newpx)
    {
        this.oldpx = oldpx;
        this.newpx = newpx;
    }
}

// add [event_handler] method:
// - for each [sub]
// - for each [unsub]

class SubscribersChangeEventArgs : System.EventArgs
{
    public SubscribersChangeEventArgs()
    {
    }
}