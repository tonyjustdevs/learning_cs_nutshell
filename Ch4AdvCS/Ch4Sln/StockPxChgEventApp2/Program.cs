using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, World!");
    }
}

// Standard Event Pattern
// [1] Create class repping ChangeEventArgs to track
// - its subclass of System.EventArgs (inherits it, a child of)
// - e.g. class PriceChangeEventArgs: System.EventArgs
// - the fields are variables (event args) to track
// - [later] instantiation of this cls passed to delegate as a arg

// [2] Define/Choose Delegate type for event:
// - must end in EventHandler
// - must 2 exact arguments:
// arg1: type 'object' - the event broadcaster
// arg2: subclass of 'EventArgs' - extra information 

// [2a] .NET defines generic delegate called:
// - System.EventHandler<>:
// - EventHandler<TEventArgs>(object source, TEventArgs e)
// - [prior c#2.0]
// - public delegate void PriceChgHandler(object src, PriceChgEventArgs e)

// [3] define the 'event' (modifier) of this delegate type
// Using the generic EventHandler:
// - public event EventHandler<PriceChgEventArgs> PriceChanged;

// [4] Add a 'protected virtual method' that fires the event
// - Method must match name of event with prefix 'On'
// - accept single EventArgs argments:
// - void protected virtual method(EventArgs e)
// { PriceChanged?.Invoke(this,e); }