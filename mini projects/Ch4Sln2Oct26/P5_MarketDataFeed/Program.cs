using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Starting MarketDataFeed\n");
        string[] simulated_prices = 
        {
            "XAUUSD 2650.10",
            "XAUUSD 2650.25",
            "XAUUSD 2649.90",
            "XAUUSD 2651.20",
        };
         
        MarketDataFeed market_data_feed = new();
        market_data_feed.PriceUpdated += Trading.TradingStrategy;
        market_data_feed.PriceUpdated += Logger.PriceLogger;
        market_data_feed.PriceUpdated += RiskAnalytics.RiskMonitor;

        foreach (var price_quote_str in simulated_prices)
        {

            market_data_feed.ProcessPriceQuoteStr(price_quote_str);
        }
        
        
        WriteLine("\nEnding MarketDataFeed");
    }
}

    //MarketDataFeed
    //       |
    //       | PriceUpdated event
    //       |
    //       +----> TradingStrategy
    //       |
    //       +----> PriceLogger
    //       |
    //       +----> RiskMonitor

internal class MarketDataFeed
{
    public event EventHandler<PriceUpdatedEventArgs>? PriceUpdated;
    public void ProcessPriceQuoteStr(string pq_str)
    {
        
        string[] symbol_price_array = pq_str.Split(' ', 2);// "XAUUSD 2650.10" -> ["XAUUSD", "2650.10"]

        PriceQuote pq = new PriceQuote(symbol_price_array);
        
        if (pq is not null)
        {
            OnPriceUpdated(new PriceUpdatedEventArgs(pq));
        }
    }

    protected virtual void OnPriceUpdated(PriceUpdatedEventArgs e)
    {
        WriteLine("\n");
        PriceUpdated?.Invoke(this, e);
    }
}

public class PriceQuote
{
    string symbol;
    decimal rawprice;
    public string Symbol { get => symbol; }
    public decimal RawPrice { get => rawprice; }

    public PriceQuote(string[] SymbolPriceArray)
    {
        symbol = SymbolPriceArray[0];

        decimal.TryParse(SymbolPriceArray[1], out rawprice);
    }
}
public class PriceUpdatedEventArgs : EventArgs
{
    public readonly PriceQuote PriceQuote;

    public PriceUpdatedEventArgs(PriceQuote priceQuote)
    {
        PriceQuote = priceQuote;
    }
}

internal class RiskAnalytics
{
    public static void RiskMonitor(object? sender, PriceUpdatedEventArgs e)
    {
        WriteLine("Risk Monitor: ");
    }
}

internal class Trading
{
    public static void TradingStrategy(object? sender, PriceUpdatedEventArgs e)
    {
        if (e.PriceQuote.RawPrice > 2650)
        {
            WriteLine("TradingStrategy: Buy signal (Price > 2650)");
            return; 
        } 
        WriteLine("TradingStrategy: ");

    }

}

internal class Logger
{
    public static void PriceLogger(object? sender, PriceUpdatedEventArgs e)
    {
        WriteLine("PriceLogger: ");
    }
}