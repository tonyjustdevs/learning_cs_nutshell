using System.Reflection.Metadata;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, p2 custom events!\n");


        var telsa = new Stock("Telsa");
        telsa.PriceChangedDGFld += StockAnalytics.StockPriceChange;
        //telsa.PriceChangedDGFld2 += StockAnalytics.StockPriceChange;
        //WriteLine($"stock: {telsa.Name} | price: {telsa.Price}");
        telsa.Price = 69;
        //WriteLine($"stock: {telsa.Name} | price: {telsa.Price}");
        telsa.Price = 42;
        //WriteLine($"stock: {telsa.Name} | price: {telsa.Price}");
    }
}
class StockAnalytics
{
    public static void StockPriceChange(decimal oldpx, decimal newpx)
    {
        //WriteLine($"PxChg: {oldpx} -> {newpx}");
        WriteLine($"UNKNOWN-PxChg: {oldpx} -> {newpx}");

    }
    public static void StockPriceChange(object? sender, decimal oldpx, decimal newpx)
    {
        if (sender is Stock s)
        {
            WriteLine($"{s.Name}-PxChg: {oldpx} -> {newpx}");
            return;
        }
        WriteLine($"UNKNOWN-PxChg: {oldpx} -> {newpx}");
    }
}
public delegate void PriceChangedHandler(decimal oldpx, decimal newpx);
public delegate void PriceChangedHandler2(object? sender, decimal oldpx, decimal newpx);
class Stock
{
    private int price;
    public string Name { get; }
    public PriceChangedHandler? PriceChangedDGFld;
    //public PriceChangedHandler2? PriceChangedDGFld2;

    public Stock(string name) => this.Name = name;

    public int Price 
    { 
        get 
        {
            return price;
        }
        set 
        {
            if (price == value) return;
            decimal oldprice = price;
            price = value; // set price
            PriceChangedDGFld?.Invoke(oldprice,price);
            //PriceChangedDGFld2?.Invoke(this,oldprice,price);
            //PriceChangedDGFld?.Invoke(oldprice,price);
        }
    }
}

// Create Stock class
// + price + Name 
// + delegate mbr

// + Price {get;set -> triggers delegate call;}

// what does it mean to have a delegate member?
// - a delegate allows for methods (of same shape) to be called when delegate is called
