using static System.Console;
namespace tpnamespace; 
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday DecTypeParamsApp");

        //OpenBox<int> ClosedBoxInt;
        //ClosedBoxInt = new OpenBox<int>();
        //WriteLine(new OpenBox<int>().id);
        //OpenBox<int> ClosedBoxInt = new();
        //OpenBox<int> ClosedBoxInt = new OpenBox<int>();
        //WriteLine($"{ClosedBoxInt.id} (type: {ClosedBoxInt.GetType()})");
        var t = typeof(OpenBox<>);
        WriteLine($"t: {t}");
        WriteLine($"t.GetType(): {t.GetType()}");
        WriteLine($"t.FullName: {t.FullName}");
        WriteLine($"typeof(BoxTwo<int, int>) :{typeof(BoxTwo<int, int>)}");
        WriteLine($"typeof(BoxTwo<, >) :{typeof(BoxTwo<, >)}");
        //WriteLine($"t.Name: {t.Name}");
        //WriteLine($"t.ReflectedType: {t.ReflectedType}");
        //WriteLine($"t.Namespace: {t.Namespace}");
        ////WriteLine($"t.GenericParameterPosition: {t.GenericParameterPosition}");
        //WriteLine($"t.Assembly: {t.Assembly}");
        //WriteLine($"t.AssemblyQualifiedName: {t.AssemblyQualifiedName}");
        //WriteLine($"t.Attributes: {t.Attributes}");
        //WriteLine($"t.BaseType: {t.BaseType}");
        //WriteLine($"t.IsClass: {t.IsClass}");
        //WriteLine($"t.IsValueType: {t.IsValueType}");
        //WriteLine($"t.IsByRef: {t.IsByRef}");
    }
}

public class BoxTwo<T, K> { }
public class OpenBox<T>
{
    public int id=69;
}
