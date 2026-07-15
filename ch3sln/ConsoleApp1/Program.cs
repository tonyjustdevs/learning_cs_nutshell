using System.Diagnostics.SymbolStore;
using System.Text.RegularExpressions;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var mate = new Person(null);
    }
}

// version 1: no validation
// - must have last_name
class Person
{
    // property
    public string LastName { 
        get;
        //set{LastName = value;} }=null!;
        set{
            if (LastName is null)
            {
                throw new ArgumentException(nameof(LastName));
            }
            LastName = value;
            
                
        } }=null!;
    // constructor

    public Person(string lastname)
    {
        LastName = lastname;
    }
}