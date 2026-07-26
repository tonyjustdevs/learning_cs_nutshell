usings System.ComponentModel.DataAnnotations;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday StockPxChgApp!");
        var telsa = new Stock("TESLA");
        telsa.Price = 69;

        telsa.PxChangeHandler += StockAnalyser.PriceChangeReporter;
        //telsa.PxChangeHandler += StockAnalyser.PriceAbsChangeReporter;
        //telsa.PxChangeHandler -= StockAnalyser.PriceChangeReporter;
        telsa.Price = 666;
        telsa.Price = 420;
        //telsa.
    }
}
class StockAnalyser {
    public static void PriceChangeReporter(decimal oldpx, decimal newpx) 
    {
        WriteLine($"Price changed: '{oldpx}' to '{newpx}' (actual)");
    }
    public static void PriceAbsChangeReporter(decimal oldpx, decimal newpx)
    {
        WriteLine($"Price changed: '{newpx-oldpx}' (absolute)");
    }
}

delegate void PriceChangeHandler(decimal oldpx, decimal newpx);
// this is a delegate
// - create an instance of this delegate by assigning a method matching the signature:
// - PriceChangeHandler pch = SomeMethod(decimal, decimal);
class Stock
{
    string stock = null!;
    decimal price;
    public Stock(string stock)
    {
        this.stock = stock;
    }
    public event PriceChangeHandler PxChangeHandler;

    public decimal Price
    {
        get
        {
            return price;
        }
        set
        {
            if (price == value) return;
            decimal oldpx = price;
            price=value;
            if (PxChangeHandler is null)
            {
                WriteLine("Something changed but no one cares! (no subs)");
                return;
            }
            PxChangeHandler(oldpx, price);
        }
    }
}
// add DG: void(old px, new px)
// add Stock cls:
// - add prv stock
// - add prv price
// - add dg px_handler
// - add property Price
// --- get {price}
// --- set {
//      i. return if px not changed
//     ii. old=px, px=val
//    iii. fire event}
