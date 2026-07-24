using System.Diagnostics;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("gday gen stack");

        //var object_stack = new StackV2();
        //object_stack.Push(new { mate = "cunt", sex = true, id = 420 });
        //object_stack.Push(new { id = 69 });
        //object_stack.Push("broskie cuz");
        //object_stack.Push(new int[] {1,2,3,4});
        //WriteLine(object_stack);

        // 1. Push(): [string] s
        // 2. Pop():  downcast to [int]
        //var stack = new StackV2();
        var stack = new GenStack<string>();
        stack.Push("s");
        //stack.Push(null);
        //int i = (int)stack.Pop(); cast exception
        //var istr = (string)stack.Pop();
    }
}

class Stack
{
    public int i;
    public object[] data = new object[50];
    public void push(object obj)=>data[i++] = obj;
    public object pop()=>data[--i];

}


class StackV2
{
    int position;
    object[] data = new object[50];
    public void Push(object obj) 
    {
        WriteLine($"pushed: {obj} ({obj.GetType()})");
        data[position++] = obj;
    }
    
    //public void PushOG(object obj) => data[position++] = obj;
    public object Pop(){
        var popped = data[--position];
        WriteLine($"popped: {popped} ({popped.GetType()})");
        return popped;
    }
}

//public class GenStack<T>
public class GenStack<T> where T : notnull
{
    //int position;
    T[] data = new T[100];
    public void Push(T item)
    {
        //ArgumentNullException.ThrowIfNull(item, nameof(item));
        WriteLine($"Pushed: {item}");
        //WriteLine($"Type: {item.GetType()}");
    }

}