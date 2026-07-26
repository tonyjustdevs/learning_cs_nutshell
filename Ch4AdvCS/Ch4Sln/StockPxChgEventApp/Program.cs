using System.ComponentModel;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday StockPxChgEventApp!");
        var apple = new Stock("APPL");
        //PriceChangeEventCapture
        //apple.eventHandler_PriceChange += 
        apple.eventHandler_PriceChange += AssetMonitor.PriceChangeEventCapture;
        apple.Price = 150;
        //apple.px_chg_delegate += AssetMonitor.PriceChangeCapture;
        apple.Price = 120;
        apple.Price = 200;
    }
}

class PriceChangeEventArgs : System.EventArgs
{
    public readonly decimal oldpx;
    public readonly decimal newpx;
    public PriceChangeEventArgs(decimal oldpx, decimal newpx)
    {
        this.oldpx = oldpx;
        this.newpx = newpx;
    }
}

class AssetMonitor
{
    public static void PriceChangeCapture(decimal oldpx, decimal newpx)
    {
        WriteLine($"{oldpx} to {newpx}");
    }

    public static void PriceChangeEventCapture(object? sender, PriceChangeEventArgs e) 
    { 
        WriteLine($"{((Stock)sender).stock} price change: '{e.oldpx}' to '{e.newpx}'");
    }

}
delegate void PriceChangeHandler(decimal oldpx, decimal newpx);
class Stock
{
    public string stock=null!;
    decimal price;
    public event PriceChangeHandler px_chg_delegate;
    public EventHandler<PriceChangeEventArgs> eventHandler_PriceChange; 
    // event handler: iscalled on price (change) via set: e.g. appl.Price = 50;
    // - we can add subscribers/listeners to this event if the listener matches the event signature
    // - (object sender, EventArgs e)
    // - task: create method to capture the event
    public Stock(string stock) => this.stock = stock;

    public void OnPriceChange(object sender, PriceChangeEventArgs e)
    {
        WriteLine("Stock.OnPriceChange() called...");
        WriteLine("Stock.eventHandler_PriceChange().Invoke(sending e) to be called...");
        if (eventHandler_PriceChange is null)
        {
            WriteLine("Stock.eventHandler_PriceChange is null!! no subs!");
        }
        eventHandler_PriceChange?.Invoke(sender, e);
    }
    public decimal Price
    {   get => price;
        set 
        {
            if (price == value) return; // return if no chg
            decimal oldpx = price;
            price = value;

            OnPriceChange(this, new PriceChangeEventArgs(oldpx,price));

            //if (px_chg_delegate is null)
            //{
            //    WriteLine("A change occured but on one saw it! (no subs).");
            //    return;
            //}
            //px_chg_delegate.Invoke(oldpx, price);
        } 
    }
}

class TonysEventArgs : System.EventArgs
{
    // when TonysEventArgs() is instantiated
    // static TonysEventArgs.Empty() ---> pts to shared EventArgs instance

}


    // 0: If every event looked different:
    // - delegate void MouseMoved(x,y)
    // - delegate void FileOpened(string name)
    // Each delegate signature is different and 

    // Microsoft decided ALL events look the same:
    // (object sender, PriceChangedEventArgs e)

    // 2:
    // PriceChangedHandler -> EventHandler<TEventArgs>
