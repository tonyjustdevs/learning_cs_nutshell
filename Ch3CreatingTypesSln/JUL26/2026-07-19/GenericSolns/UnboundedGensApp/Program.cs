using System.Collections;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hi Unbounded Generics!");
        List<int> list_instance = new() { 12, 42, 69, 666 };
        // 1. get type of instance

        if (false)
        {
            Type probably_gen_type_def = typeof(List<>);
            Type list_type = list_instance.GetType();
            WriteLine($"list_instance.GetType(): {list_type} (exp: sys.coll.genlist[int])");
            WriteLine($"typeof(List<>): {probably_gen_type_def} (exp: sys.coll.genlist[T])");

            // 2. check if is generic?
            WriteLine($"list<int>_type.IsGenericType: {list_type.IsGenericType} (exp: true)");
            WriteLine($"list<int>_type.IsGenericTypeDefinition: {list_type.IsGenericTypeDefinition} (exp: false)");

            WriteLine($"typeof(List<>).isgen: {probably_gen_type_def.IsGenericType} (exp: true)");
            WriteLine($"typeof(List<>).isgendef: {probably_gen_type_def.IsGenericTypeDefinition} (exp: true)");
            // 3. get generic definition
            list_type.GetGenericTypeDefinition();
            // 4. conversion to collection inteface

            // list_type: System.Collections.Generic.List`1[System.Int32]
            // list_type.IsGenericType: True
            // list_type.IsGenericTypeDefinition: False
        }


        object list_object = list_instance;
        WriteLine(list_object);                                 // System.Collections.Generic.List`1[System.Int32]

        Type instance_type = list_object.GetType();
        var instance_gentype_def = instance_type.GetGenericTypeDefinition(); 
        WriteLine($"gen_type_def: {instance_gentype_def} (exp: List<T>)");                                     // System.Collections.Generic.List`1[T]
        WriteLine($"typeof_listT: {typeof(List<>)} (exp: List<T>)");

        //var icol_object = (System.Collections.ICollection)list_object;
        var icol_obj_count = ((ICollection)list_object).Count;
        WriteLine($"((ICollection)list_object).Count: {((ICollection)list_object).Count}");
    }
}

// psuedo-code
// 1. get type of instance
// 2. check if is generic?
// 3. get generic definition
// 4. conversion to collection inteface
