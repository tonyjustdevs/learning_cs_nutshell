using System.Xml;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello EnumIterApp1!");

        // 1. add Trade Class: + .Symbol + .Volume
        // 2. add List<Trade> trades: add a couple trades
        // 3. add GetLargeTrades -> foreach and filter volume>n
        List<Trade> trades = new List<Trade>()
        {
            new Trade("spcx",100),
            new Trade("tsla",69),
            new Trade("msft",420)
        };
        var large_trades = GetLargeTrades(trades);
        var large_tradesIE = GetLargeTradesIE(trades);

        foreach (var trade in large_tradesIE)
        {
            WriteLine($"Symbol: {trade.Symbol} Volume: {trade.Volume}");
        }
    }

    static List<Trade> GetLargeTrades(List<Trade> trades)
    {
        List<Trade> LargeTrades = new List<Trade>();
        foreach (var trade in trades)
        {
            if (trade.Volume >= 100)
            {
                LargeTrades.Add(trade);
            }
        }
        return LargeTrades;
    }

    static IEnumerable<Trade> GetLargeTradesIE(List<Trade> trades)
    {
        List<Trade> LargeTrades = new List<Trade>();
        foreach (var trade in trades)
        {
            if (trade.Volume >= 100)
            {
                yield return trade;
            }
        }
        //return LargeTrades;
    }
}

class Trade
{
    string _symbol = null!;
    int _volume;

    public Trade(string symbol, int volume)
    {
        Symbol = symbol;
        Volume = volume;
    }

    public int Volume { get => _volume; set => _volume = value; }
    public string Symbol { get => _symbol; set => _symbol = value; }
}


