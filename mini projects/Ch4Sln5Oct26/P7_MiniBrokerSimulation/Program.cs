
using System.Collections;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Console;
internal class Program
{
    // create 

    public static Dictionary<string, Instrument> instruments_repo = new Dictionary<string, Instrument>();
    static void Main(string[] args)
    {
        WriteLine("Hello, P7_MiniBrokerSimulation!");

        // [1] setup repo
        Instrument xauusd = new Instrument("XAUUSD", 2650.00m);
        xauusd.PriceUpdated += TradingStrategy.PriceTracker;
        instruments_repo.Add(xauusd.Symbol, xauusd); // ADD default symbol
        WriteLine("setup: {0}",instruments_repo["XAUUSD"].Price);

        OrderEngine order_engine = new OrderEngine();

        // [2] run simulation
        string[] quotes =
        [
            "09:30:01 XAUUSD = 2650.10",
            "09:30:02 XAUUSD = 2650.40",
            "09:30:03 XAUUSD = 2651.00"
        ];
        foreach (var quote in quotes)
        {
            string symbol = quote.Substring(9, 6);

            decimal.TryParse(quote.Split(' ', 4)[3], out decimal new_price);

            instruments_repo["XAUUSD"].Price = new_price;

            WriteLine("update: {0}", instruments_repo["XAUUSD"].Price);
            
        }



        // [1] single [Stock] object represented by [Symbol], last [Price],...
        // [2] for each quote: filter/find [Stock] 
        // [3] update stock price
        // [4] - trigger event -> buy signal
        // [6] Order engine -> execute order
        // [7] - trigger event -> risk monitor
        // [8] - trigger event -> logger
    }
}

internal class OrderEngine
{
    public OrderEngine()
    {
    }

    
}

internal class TradingStrategy
{
    public static event EventHandler<BuySignalEventArgs>? BuySignal;
    // [1] setup instrument buy signal price

    // "xauusd": {(xauusd,buyprice)}
    internal static void PriceTracker(object? sender, PriceUpdateEventArgs e)
    {   // sender is always Instrument
        //Instrument? s = sender as Instrument;
        if (e.NewPrice >= 2651)
        {
            OnBuySignal(new BuySignalEventArgs(e.NewPrice));
        }
    }

    private static void OnBuySignal(BuySignalEventArgs e)
    {
        BuySignal?.Invoke(e);
    }
}

public class BuySignalEventArgs : EventArgs
{
    private decimal _targetPrice = 2651;

    public BuySignalEventArgs(decimal newPrice)
    {
        this._targetPrice = newPrice;
    }
}

public class Instrument
{
    public string Symbol{ get; }
    private decimal price;

    public event EventHandler<PriceUpdateEventArgs>? PriceUpdated;
    public decimal Price
    {
        get { return price; }

        set
        {
            if (value == price) return;
            decimal oldprice = price;
            price = value;
            OnPriceUpdated(new PriceUpdateEventArgs(oldprice,price));
        } 
    }

    public void OnPriceUpdated(PriceUpdateEventArgs e)
    {
        PriceUpdated?.Invoke(this, e);
    }

    public Instrument(string symbol, decimal price)
    {
        Symbol = symbol;
        Price = price;
    }
};




// simulation
// 09:30:01 XAUUSD = 2650.10
// 09:30:02 XAUUSD = 2650.40
// 09:30:03 XAUUSD = 2651.00

// Strategy:
// BUY signal

// OrderEngine:
// BUY 1.0 XAUUSD @ 2651.00

// RiskMonitor:
// Exposure = $2651

// Logger:
// Order #1001 executed


class MarketDataFeed
{
    public event EventHandler<PriceUpdateEventArgs>? PriceUpdated;
}

public class PriceUpdateEventArgs : EventArgs
{
    public decimal OldPrice{ get; }
    public decimal NewPrice{ get; }

    public PriceUpdateEventArgs(decimal oldprice, decimal newprice)
    {
        OldPrice = oldprice;
        NewPrice = newprice;
    }


}

//  MarketDataFeed
//         │
//         │ PriceUpdated
//         ↓
//  TradingStrategy
//         │
//         │ PlaceOrder()
//         ↓
//  OrderEngine
//         │
//         │ OrderExecuted
//         ↓
//  ┌──────┴───────────┐
//  ↓                  ↓
//  RiskMonitor        Logger

// Just objects communicating through delegates/events.


