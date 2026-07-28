partial class Program
{
    static List<string> GetBigTrades(string[] trades_array)
    {
        List<string> trades_array_big = new List<string>();
        for (int i = 0; i < trades_array.Length; i++)
        {
            if (int.Parse(trades_array[i].Split(',')[1]) >= 98)
            {
                trades_array_big.Add(trades_array[i]);
            }
        }
        return trades_array_big;
    }

    static IEnumerable<string> GetBigTradesIE(string[] trades_array)
    {
        //List<string> trades_array_big = new List<string>();
        for (int i = 0; i < trades_array.Length; i++)
        {
            if (int.Parse(trades_array[i].Split(',')[1]) >= 98)
            {
                //trades_array_big.Add(trades_array[i]);
                yield return trades_array[i];
            }
        }
        //return trades_array_big;
    }
}
