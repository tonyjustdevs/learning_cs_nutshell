//namespace bro;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //object

        double a=0;             //1. numeric conversion
        int b = (int)a;

        object o = new StringBuilder();         // 2. reference conversion
        StringBuilder sb = (StringBuilder)o;    // - [ref-value] is boxed &  unboxed
                                                
        object o2 = 42;                         // 3. boxing/unboxing
        var val = (int)o2;                      // - [value-type] is boxed &  unboxed

    }
}


// there are diff kinds of casts
// 1. numeric
// 2. reference
// 3. boxing

//public class Employee:IEquatable<Employee>
//{
//    int _eeID;
//    string name = null!;

//    public bool Equals(Employee? other)
//    {
//        return _eeID == other?._eeID;
//    }
//}
//public class MyClass<T>
//{
//    static T Max<T>(T a, T b) where T : IComparable<T>
//    {
//        return a.CompareTo(b)>0?a:b;
//    }
//}


