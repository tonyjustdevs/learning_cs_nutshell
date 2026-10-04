using System.Drawing;
using System.Linq.Expressions;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi p4 trade execution notifcation system!\n");
        TradeEngine trade_engine = new TradeEngine();
        trade_engine.TradeExecuted += Logger.TradeLogger;
        trade_engine.TradeExecuted += RiskAnalytics.RiskMonitor;
        trade_engine.TradeExecuted += MessageService.NotificationService;

        // create trade
        Trade trade = new Trade("XAUUSD", "BUY", "1.5", "2650.20", "tid1234");
        trade_engine.ExecuteTrade(trade);
    }
}

class Logger
{
    public static void TradeLogger(object? sender, TradeDataEventsArgs e)
    {
        if (sender is TradeEngine te)
        {
            WriteLine("\nTradeLogger: \nTrade recorded.");
        }   
    }
}

class RiskAnalytics
{
    public static void RiskMonitor(object? sender, TradeDataEventsArgs e) 
    {
        if (sender is TradeEngine te)
        {
            WriteLine("\nRiskMonitor: \nChecking exposure...");
        }
    }
}

class MessageService
{
    public static void NotificationService(object? sender, TradeDataEventsArgs e)
    {
        if (sender is TradeEngine te)
        {
            WriteLine("\nNotificationService: \nTrade executed....");
        }
    }
}


class TradeEngine
{

    public event EventHandler<TradeDataEventsArgs>? TradeExecuted;
    protected virtual void OnTradeExecuted(TradeDataEventsArgs e)
    {
        TradeExecuted?.Invoke(this, e);
    }
    public void ExecuteTrade(Trade trade) // trade executes, raise an event.
    {
        // [a] trade is executed
        WriteLine($"{trade.Side} {trade.Volume} {trade.Symbol} @ {trade.Price}"); //BUY 1.5 XAUUSD @ 2650.20
        
        // [b] raise event
        OnTradeExecuted(new TradeDataEventsArgs(trade.Symbol, trade.Side, trade.Volume, trade.Price, trade.Tradeid));
        //OnTradeExecuted(new TradeDataEventsArgs(trade));
    }
}
class Trade
{
    private string symbol;
    public string Symbol =>symbol;  
    private string side;
    public string Side =>side;  
    private string volume;
    public string Volume =>volume;  
    private string price;
    public string Price =>price;  
    private string tradeid;
    public string Tradeid => tradeid;

    public Trade(string symbol, string side, string volume, string price, string tradeid)
    {
        this.symbol = symbol;
        this.side = side;
        this.volume = volume;
        this.price = price;
        this.tradeid = tradeid;
    }

        
}

class TradeDataEventsArgs:EventArgs
{

    public readonly string symbol;
    public readonly string side;
    public readonly string volume;
    public readonly string price;
    public readonly string tradeid;


    public TradeDataEventsArgs(string symbol, string side, string volume, string price, string tradeid)
    {
        this.symbol = symbol;
        this.side = side;
        this.volume = volume;
        this.price = price;
        this.tradeid = tradeid;
    }

}