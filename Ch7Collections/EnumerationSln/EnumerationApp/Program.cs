using System.Collections;
using System.ComponentModel;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        //OrderBook orderbook = new();
        //foreach (var item in new TonysCollectionCls())
        //{
        //    WriteLine(item);
        //}

        //foreach (var item in new TonysTradeRepo())
        //{
        //    WriteLine(item);
        //}

        var tp_orders = new TonysOrderCollection();
        tp_orders.Add(new TradeOrder() { Id = 42, Symbol = "XAUUSD", Qty = 100 });
        tp_orders.Add(new TradeOrder() { Id = 69, Symbol = "AUDUSD", Qty = 50 });
        tp_orders.Add(new TradeOrder() { Id = 50, Symbol = "EURUSD", Qty = 10 });
        tp_orders.Add(new TradeOrder() { Id = 12, Symbol = "BTCAUD", Qty = 66 });

        TradeOrder[] tp_array = new TradeOrder[tp_orders.Count];
        WriteLine("\npre_copy:");

        foreach (var item in tp_array)
        {
            WriteLine(item);
        }

        WriteLine("\npst_copy:");
        tp_orders.CopyTo(tp_array,0);
        foreach (var item in tp_array)
        {
            WriteLine(item);
        }


    }


}



// Two design options
// 1. the collection is the class

class TradeOrder
{
    int id;
    string symbol = null!;
    int qty;

    public int Id { get => id; set => id = value; }
    public string Symbol { get => symbol; set => symbol = value; }
    public int Qty { get => qty; set => qty = value; }

    public override string? ToString()
    {
        //return base.ToString();
        return $"[id: {Id}] {Symbol}, {Qty}";
    }
}

class OrderBook : IEnumerable<TradeOrder>
{
    private List<TradeOrder> _orders = new() 
    {
        new TradeOrder(){Id=42,Symbol="XAUUSD",Qty=100},
        new TradeOrder(){Id=69,Symbol="AUDUSD",Qty=50},
        new TradeOrder(){Id=50,Symbol="EURUSD",Qty=10},
        new TradeOrder(){Id=12,Symbol="BTCAUD",Qty=66}
    };
    public IEnumerator<TradeOrder> GetEnumerator()
    {
        return _orders.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class TradingSession
{
    List<TradeOrder> _orders = new();

    IEnumerable<TradeOrder> Orders => _orders;
}

class TonysCollectionCls : IEnumerable
{
    int[] numbers = { 42, 69, 666 };

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            yield return numbers[i];
        }
    }
}

class TonysTradeRepo : IEnumerable<TradeOrder>
{
    List<TradeOrder> _orders = new() 
    {
        new TradeOrder(){Id=1, Symbol="AUDUSD", Qty=1},
        new TradeOrder(){Id=2, Symbol="EURUSD", Qty=2},
        new TradeOrder(){Id=3, Symbol="XAUUSD", Qty=3},
        new TradeOrder(){Id=4, Symbol="VNDUSD", Qty=4},
        new TradeOrder(){Id=5, Symbol="NZDUSD", Qty=5},
    };
    public IEnumerator<TradeOrder> GetEnumerator()
    {
        for (int i = 0; i < _orders.Count; i++)
        {
            yield return _orders[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class TPICollection : ICollection
{
    public int Count => throw new NotImplementedException();

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
class TonysOrderCollection : ICollection<TradeOrder>
{
    List<TradeOrder> _orders = new();
    public int Count => _orders.Count;

    public bool IsReadOnly => false;

    public void Add(TradeOrder item)=>_orders.Add(item);
    public void Clear() => _orders.Clear();
    public bool Contains(TradeOrder item) => _orders.Contains(item);

    public void CopyTo(TradeOrder[] array, int arrayIndex) => _orders.CopyTo(array, arrayIndex);
    public IEnumerator<TradeOrder> GetEnumerator()=>_orders.GetEnumerator();
    public bool Remove(TradeOrder item) => _orders.Remove(item);

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

