using System.ComponentModel.DataAnnotations;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Timer Event App");
        Stock spacex = new("spacex");
        // [TEST-1] above direct '=' works because not an 'event'
        spacex.Price = 1; // [TEST-2] EXP: FAIL
        // price changed but no one is subscribed!!
        //spacex.priceChangeHandler += stock_PriceChangeAbsolute; // OLD: custom delegate
        spacex.PriceChangeHandler += stock_PriceChangeAbsoluteSEP; // new: standard event pattern
        // CS0070:
        // The event 'Stock.priceChangeHandler' can only appear on the left hand side of += or -=
        // (except when used from within the type 'Stock')
        spacex.Price = 69;                                      // stock price change: 1 -> 69
        spacex.Price = 42;                                      // stock price change: 69 -> 42
        //spacex.priceChangeHandler += null;
        //spacex.PriceChangeHandler -= stock_PriceChangeAbsolute;
        spacex.PriceChangeHandler -= stock_PriceChangeAbsoluteSEP;
        spacex.Price = 666;                                     // price changed but no one is subscribed!!
        spacex.Price = 420;                                     // price changed but no one is subscribed!!
        //spacex.PriceChangeHandler += stock_PriceChangeAbsolute;
        spacex.PriceChangeHandler += stock_PriceChangeAbsoluteSEP;
        spacex.Price += 1;                                      // stock price change: 420 -> 421

        // [TEST-2] above direct '=' should fail when an 'event'
        // - should only work with '+=' or '-='
    }
    static void stock_PriceChangeAbsoluteSEP(object? sender, PriceChangeEventArgs e)
    {
        if (sender is not null)
        {
            WriteLine($"'{((Stock)sender).stock}' price change: {e.Oldpx} -> {e.Newpx}");
            return;
        }
    }


    static void stock_PriceChangeAbsolute(decimal oldpx, decimal newpx) 
    {
        WriteLine($"stock price change: {oldpx} -> {newpx}");
    }
}
delegate void PriceChangeHandler(decimal oldpx, decimal newpx);

class Stock (string Stock)
{

    
    //public event PriceChangeHandler? priceChangeHandler;
    private EventHandler<PriceChangeEventArgs>? priceChangeHandler;
    public event EventHandler<PriceChangeEventArgs>? PriceChangeHandler
    {
        add
        {
            priceChangeHandler += value;
            WriteLine($"new subscriber: '{value?.Method.Name}'!");
        }
        remove
        {
            priceChangeHandler -= value;
            WriteLine($"someone left you: '{value?.Method.Name}'!");
        }
    }

    public string stock { get; } = Stock;
    // Without 'event' keyword, delegate can be reassigned outside class (not good)
    // [TEST-1] create stock instance and assign PCH, then to null.
    // - expected: anything goes!

    // [TEST-2] add event tp PCH, create stock instance and assign PCH, then to null
    // - expected: disallowed assignmend of pch in main
    decimal price;

    void OnPriceChangeHandler(PriceChangeEventArgs e) 
    {
        if (priceChangeHandler is null)
        {
            WriteLine("price changed but no one is subscribed!!");
            return;
        }
        priceChangeHandler?.Invoke(this, e);
    }
    public decimal Price
    {
        get { return price; }
        set 
        {   
            // [1] no change then return
            if (value == price) return;
            
            // [2] change: set the price and update old price
            decimal oldpx = price;
            price = value;

            //// [3v1] fire handler
            ////priceChangeHandler?.Invoke(oldpx,price); // [.?] implies null: no trigger when null
            //if (PriceChangeHandler is null)
            //{
            //    WriteLine("price changed but no one is subscribed!!");
            //    return;
            //}
            ////priceChangeHandler.Invoke(oldpx,price);   // OLD: custom delegate
            //PriceChangeHandler.Invoke(this, new PriceChangeEventArgs(oldpx,price)); // NEW_v1: standard event pattern

            OnPriceChangeHandler(new PriceChangeEventArgs(oldpx, price));
            //priceChangeHandler?.Invoke(this, new PriceChangeEventArgs(oldpx, price));
        }
    }
}

// An 'event' is a modifer to a 'delegate' type
// When a 'delegate' is called,
// - it automatically calls other methods assigned to it
// - these other methods match the signature of the delegate
// When an event is triggered (or called), it also calls other methods (ass to it)
// - the only real difference is events have specific rules/syntax
// - over how subscribers are assigned/removed from events

// An 'EventHandler'


class PriceChangeEventArgs : System.EventArgs
{
    public decimal Oldpx;
    public decimal Newpx;

    public PriceChangeEventArgs(decimal oldpx, decimal newpx)
    {
        Oldpx = oldpx;
        Newpx = newpx;
    }
}