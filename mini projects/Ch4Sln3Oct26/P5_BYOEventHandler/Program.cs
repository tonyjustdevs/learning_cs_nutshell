using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P5_BYOEventHandler!");

        TradeEngine te = new TradeEngine();
        te.TradeExecuted += Logger.TradeLogger;

        te.ExecuteTrade(new Trade());
    }

    
}

internal class Logger
{
    public static void TradeLogger(object? sender, TradeExecutedEventArgs e)
    {
        WriteLine("TradeLogger: ");
    }
}

class TradeEngine
{
    public delegate void TradeExecutedEventHandler(object? sender, TradeExecutedEventArgs e);
    public event TradeExecutedEventHandler? TradeExecuted; // a field of type TradeExecutedEventHandler
    public void ExecuteTrade(Trade trade)
    {

        OnTradeExecuted(new TradeExecutedEventArgs(trade));
    }

    private void OnTradeExecuted(TradeExecutedEventArgs e)
    {
        TradeExecuted?.Invoke(this, e);
    }
}

public class Trade
{
}

internal class TradeExecutedEventArgs
{
    public Trade Trade { get; }
    public TradeExecutedEventArgs(Trade trade)
    {
        Trade = trade;
    }

}

// TradeEngine
//      |
//      |ExecuteTrade event raised
//      |
//      +---sub1 (e.g. logger)
//      |
//      +---sub1 (e.g. risk monitor)
//      ...


// [1] Add custome dg
//  delegate void TradeExecutedHandler(
//  object sender,
//  TradeExecutedEventArgs e);

// [2] use for event

// [3] replace with 
// EventHandler<TradeExecutedEventArgs>

// [4] show same

