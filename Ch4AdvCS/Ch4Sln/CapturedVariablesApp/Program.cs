using System.Reflection.Metadata.Ecma335;
using System.Transactions;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("G'day Prisoners");

        // build Quote delegate
        // - captures outer-variable: 'spread'
        // - returns a price+spread
        decimal spread = 0.5m;
        Func<decimal, decimal> Quote = (price) => price + spread;
        WriteLine($"Quote(100): {Quote(100)}"); 
        spread = 1.5m;
        WriteLine($"Quote(105): {Quote(105)}");
    }

    static Func<int> FuncIntDGRetter()
    {
        int x = 42;
        return () => x + 27;
    }

    // [1a] what is Func<int>? a delegate type -> int
    //Func<int> IntRetter;
    delegate int IntRetter();

    static int Return42() => 42;
}

//Func<int> IntReturner = LifeGiver;
//WriteLine($"IntReturner(): {IntReturner()}");

//Func<int> IntReturner2 = () => 69; 
//WriteLine($"IntReturner2(): {IntReturner2()}");


// [1] write a method that returns Func<int>

// [recall] lambda expression:
// - are [unnamed_methods] in place
// - of a [delegate instance]

// [0a] write a Func<int> delegate
// [0b] write a Func<int> via lambda expression