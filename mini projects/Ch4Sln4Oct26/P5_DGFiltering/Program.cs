using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday P5-DG-Filtering\n");

        // Dynamic used on purpose to test how to use
        // Should use Trade Class as param instead in real world
        WriteLine("\ntrade => trade.Symbol == \"XAUUSD\":");
        FindTrades(trade => trade.Symbol == "XAUUSD");
        WriteLine("\ntrade => trade.Volume > 1:");
        FindTrades(trade => trade.Volume > 1);
        WriteLine("\ntrade => trade.Side == \"BUY\":");
        FindTrades(trade => trade.Side == "BUY");

        void FindTrades(Func<dynamic,bool> delegatefilter)
        {
            dynamic[] trades_arr = 
            [
                new{Symbol= "XAUUSD",Side= "BUY ",Volume=1.0},
                new{Symbol= "EURUSD",Side= "SELL",Volume=2.0},
                new{Symbol= "XAUUSD",Side= "SELL",Volume=0.5},
                new{Symbol= "USDJPY",Side= "BUY ",Volume=1.5}
            ];

            foreach (var item in trades_arr)
            {
                WriteLine($"- [{item.Symbol}|{item.Side}|{item.Volume:F1}]: {delegatefilter(item)}");
            }
        }
    }

}