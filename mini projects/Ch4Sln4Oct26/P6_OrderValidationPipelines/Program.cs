using System.Data.Common;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P6_OrderValidationPipelines!");

        var order1 = new Order("AUDUSD", 1.0m, 0.69420m, "Buy");
        WriteLine("checking order1:\n");

        if (ValidateOrder(order1, CheckVolume)       &&
            ValidateOrder(order1, CheckSymbol)       &&
            ValidateOrder(order1, CheckTradeHrs)     &&
            ValidateOrder(order1, CheckRisk)
        )
        {
            WriteLine("ok");
            return;
        }
        WriteLine("reject");
    }

    public static bool CheckVolume(Order order)
    {
        WriteLine("CheckVolume: true"); return true;
    }

    public static bool CheckSymbol(Order order)
    {
        WriteLine("CheckSymbol: true"); return true;
    }

    public static bool CheckTradeHrs(Order order)
    {
        WriteLine("CheckTradeHrs: false"); return false;
    }

    public static bool CheckRisk(Order order)
    {
        WriteLine("CheckRisk: false"); return false;
    }

    public static bool ValidateOrder(Order order, Func<Order,bool> orer_val_function)
    {
        return orer_val_function(order);
    }
}

public record Order(string Symbol, decimal Volume, decimal Price, string Side);

// [1] Order object
//  Order
//   ├── Symbol
//   ├── Volume
//   ├── Price
//   └── Side

// [2] ValidateOrder(... )

// [3] Caller provides [validation-functions]
//  CheckVolume, CheckSymbol, CheckTradingHours, CheckRisk
//  Order
//    │     
//    ├── Validator 1 → true    
//    │
//    ├── Validator 2 → true
//    │
//    ├── Validator 3 → false
//    │
//    └── reject