using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P6_DelegateBasedFilter!");

        TradesDB.FindTrades(trade => trade.Symbol == "XAUUSD");
        TradesDB.FindTrades(trade => trade.Volume > 1);
        TradesDB.FindTrades(trade => trade.Side == Buy);
    }
}
class TradesDB
{
    public static void FindTrades(Func<Trade, bool> TradesFilter)
    {
        Trade[] trades_db =
        [
            new Trade(){Symbol="XAUUSD",Side="BUY",Volume=1.0},

            new Trade(){Symbol="EURUSD",Side="SELL",Volume=2.0},
            new Trade(){Symbol="XAUUSD",Side="SELL",Volume=0.5},
            new Trade(){Symbol="USDJPY",Side="BUY",Volume=1.5},
        ];

        foreach (var trade in trades_db)
        {
            WriteLine($"{trade.Symbol} - {trade.Side} - {trade.Volume}:")
            WriteLine(TradesFilter(trade));

        }
    }
}

public class Trade
{
    public string Symbol { get; init; } = null!;
    public string Side{ get; init; } = null!;
    public double Volume{ get; init; }
    
}

// method
//  FindTrades(...)

// data
//  Trade 1: XAUUSD BUY 1.0
//  Trade 2: EURUSD SELL 2.0
//  Trade 3: XAUUSD SELL 0.5
//  Trade 4: USDJPY BUY 1.5


// use
//  FindTrades(trade => trade.Symbol == "XAUUSD");
//  FindTrades(trade => trade.Side == Buy);