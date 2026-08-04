using static System.Console;

using System.Collections.ObjectModel;
using System.Data;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, CollectionApp!");

        OrderCollection orders = new();
        Order best_order = new Order() { Id = 69, Symbol = "CUNT" };
        orders.Add(new Order() { Id = 123, Symbol="AUDUSD" });
        orders.Add(best_order);
        orders.Add(new Order() { Id = 678, Symbol="XAGUSD" });

        WriteLine($"orders.IndexOf(best_order): {orders.IndexOf(best_order)}");
        
    }
}

class OrderCollection : Collection<Order>
{
    protected override void ClearItems()
    {
        WriteLine("tonys clearing up shop!");
        base.ClearItems();
    }

    protected override void InsertItem(int index, Order item)
    {
        WriteLine("tonys about to probe you! {0}", item);
        base.InsertItem(index, item);
    }

    protected override void RemoveItem(int index)
    {
        WriteLine("removing probe...");
        base.RemoveItem(index);
    }

    protected override void SetItem(int index, Order item)
    {
        WriteLine("setting a cool items");
        base.SetItem(index, item);
    }
}
class Order
{
    int id;
    string symbol = null!;
    public int Id { get => id; set => id = value; }
    public string Symbol { get => symbol; set => symbol = value; }

    public override string? ToString()
    {
        return $"Order(Id: {id}, Symbol: {Symbol})";
        //return base.ToString();
    }
}
