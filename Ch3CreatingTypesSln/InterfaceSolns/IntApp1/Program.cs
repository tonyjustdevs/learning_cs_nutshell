using System.Collections;
using System.Data;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        var stack = new  Stack();
        stack.push("sausage");
        stack.push(69);
        WriteLine(stack);
        int popped = (int)stack.pop();
        WriteLine($"popped: {popped}");
        string s = (string)stack.pop();
        WriteLine($"popped: {s}");

    }
}

public class Stack
{
    int position;
    object[] data = new object[10];
    public void push(object obj) {
        WriteLine($"pushing {obj}");
        data[position++]=obj; 
    }
    public object pop() { return data[--position]; }

    public override string? ToString()
    {
        var data_str= string.Join(",", data);
        WriteLine("overriding ToString()...");
        return $"Stack({data_str})";
        //return base.ToString();
    }
}
internal class CountDown : IEnumerator<int>
{
    public int Current => throw new NotImplementedException();

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
