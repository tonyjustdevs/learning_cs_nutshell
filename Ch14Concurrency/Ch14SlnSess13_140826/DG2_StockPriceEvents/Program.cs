using System.Diagnostics.Tracing;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
     
        WriteLine("Hello, DG2_StockPriceEvents!");

        var apple = new Stock("aapl");
        //apple.EHStockPriceChanged += stock_PriceChanged;
        apple.EHPriceChanged+= something_PriceChanged;
        apple.Price = 12;
        apple.Price = 42;
        apple.Price = 69;
        apple.Price = 0;

    }

    static void stock_PriceChanged(object? sender, StockPriceChangedEventArgs e)
    {
        if (sender is Stock s)
        {
            WriteLine($"{s.Name} price changed: {e.OldPrice} to {e.NewPrice}");
            
        }
    }

    static void something_PriceChanged(object? sender, EventArgs e)
    {
        if (sender is Stock s)
        {
            WriteLine($"{s.Name} price changed!");

        }
    }
}


//class 
class Stock
{
    #region [1] Fields
    string _name = null!;
    decimal _price;
    #endregion

    public string Name { get => _name; init => _name = value; }

    #region [2] Event-Handlers
    public EventHandler<StockPriceChangedEventArgs>? EHStockPriceChanged;
    public EventHandler? EHPriceChanged;

    public Stock(string name)
    {
        Name = name;
    }

    protected virtual void OnEHStockPriceChanged(StockPriceChangedEventArgs e)
    {
        //WriteLine("OnStockPriceChanged() triggered...");
        EHStockPriceChanged?.Invoke(this, e);
    }
    protected virtual void OnEHPriceChanged(EventArgs e)
    {
        //WriteLine("OnStockPriceChanged() triggered...");
        EHPriceChanged?.Invoke(this, e);
    }
    #endregion

    #region [3] Properties
    public decimal Price { 
        get => _price; 
        set 
        {
            if (_price == value) return;
            decimal oldprice = _price;
            _price = value;
            OnEHStockPriceChanged(new StockPriceChangedEventArgs(oldprice, _price));
            OnEHPriceChanged(EventArgs.Empty);
        } 
    }
    #endregion
}

class StockPriceChangedEventArgs : EventArgs
{
    public readonly decimal OldPrice;
    public readonly decimal NewPrice;

    public StockPriceChangedEventArgs(decimal oldPrice, decimal newPrice)
    {
        OldPrice = oldPrice;
        NewPrice = newPrice;
    }
}
