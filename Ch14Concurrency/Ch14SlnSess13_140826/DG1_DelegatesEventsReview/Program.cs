using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, DG1_DelegatesEventsReview!");
        var spcx = new Stock("SPCX");

        spcx.priceStockChanged += StockPriceChangeEventHandler;
        //spcx.EH_PriceStockChanged+= StockPriceChangeEventHandler;
        //spcx.priceChanged += StockPriceChange;
        spcx.Price = 42;
        spcx.Price = 69;
        spcx.Price = 12;

    }

    static void StockPriceChangeEventHandler(object? sender, StockPriceChangeEventArgs e)
    {
        if (sender is Stock s)
        {
            WriteLine($"{s.Name} Price Change: {e.Oldprice} to {e.Newprice}");
        }
    }
    static void StockPriceChange(decimal old_price, decimal new_price)
    {
        WriteLine($"Price Change: {old_price} to {new_price}");
    }
}

delegate void priceChangeHandler(decimal oldpx, decimal newpx);
delegate void priceStockChangeHandler(object? sender, StockPriceChangeEventArgs e);

class Stock
{
    string _name = null!;
    decimal _price;
    private string name;

    //public event priceChangeHandler? priceChanged;
    public event priceStockChangeHandler? priceStockChanged;
    public event EventHandler<StockPriceChangeEventArgs> EH_PriceStockChanged;

    public Stock(string name)
    {
        Name = name;
    }

    protected virtual void OnEH_PriceStockChanged(StockPriceChangeEventArgs e)
    {
        WriteLine("EH_PriceStockChanged fired!");
        EH_PriceStockChanged?.Invoke(this, e);
    }
    void OnPriceStockChanged(StockPriceChangeEventArgs e)
    {
        WriteLine("OnPriceStockChanged() triggered...");
        priceStockChanged?.Invoke(this, e);
    }
    public decimal Price { 
        get => _price; 
        set 
        {
            if (_price == value) return;
            decimal oldprice = _price;
            _price = value;
            //priceChanged?.Invoke(oldprice, _price);
            OnPriceStockChanged(new StockPriceChangeEventArgs(oldprice, _price));
        } 
    }

    public string Name { get => _name; init => name = value; }
}

class StockPriceChangeEventArgs : EventArgs
{
    private readonly decimal _oldprice;
    private readonly decimal _newprice;

    public StockPriceChangeEventArgs(decimal oldprice, decimal newprice)
    {
        _oldprice = oldprice;
        _newprice = newprice;
    }

    public decimal Oldprice => _oldprice;

    public decimal Newprice => _newprice;
}