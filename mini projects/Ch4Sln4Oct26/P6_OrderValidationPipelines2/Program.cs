using System.Collections.Frozen;
using static System.Console;

internal class Program
{

    static void Main(string[] args)
    {
        WriteLine("Hello, World!");
        List<Func<Order, bool>> validators =
        [
            CheckVolume,
            CheckSymbol,
            CheckPrice,
            CheckRisk

        ];

        var order = new Order(){Symbol="XAUUSD",Price=50m,Risk=500,Volume=2.0m};

        WriteLine($"Validation result: { ValidateOrder(order, validators)}");

        bool CheckSymbol(Order order)
        {
            FrozenSet<string> valid_symbols = ["XAUUSD", "AUDUSD", "EURUSD"]; // ETC

            return valid_symbols.Contains(order.Symbol);
        }
        bool CheckVolume(Order order)=> order.Volume>=0 ? true: false;
        bool CheckPrice(Order order)=>order.Price>=0 ? true: false;
        bool CheckRisk(Order order)=>order.Risk<1_000 ? true: false;
        
    }
    public static bool ValidateOrder(Order order, List<Func<Order, bool>> validators)
    {
        foreach (var validator in validators)
        {
            if (!validator(order))
            {
                return false;
            }

        }
        return true;

    }
}

internal class Order
{
    public string Symbol { get; init; } = null!;
    public decimal Volume { get; init; }
    public decimal Price { get; init; }
    public decimal Risk { get; init; }
}