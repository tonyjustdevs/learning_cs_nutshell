using static System.Console;
using System.Text;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Params!");

        // 1. build a string
        // - a variable 'sb' (holds a reference)
        // - points to [SB_object]
        // like a [remote](ptr) pointing to a [tv](obj)

        // 2. create method 'Foosb' param
        // - another copy of same reference
        // - point to same [SB_object]
        // - like a second [remote](ptr) to same [tv](obj)
        //stringbuilder
        StringBuilder? sb = new StringBuilder(); // 'sb' variables: holds ref to SB() object
        WriteLine($"pre-sb-byval: {sb}");
        SB_Append_ByVal(sb);                // object appended with "broskies"
        WriteLine($"pre-sb-byval: {sb}\n");

        WriteLine($"pre-sb-byref: {sb}");   // object: "broskies"
        SB_Append_ByRef(ref sb);            // pass [sb] ptr
        WriteLine($"pst-sb-byref: {sb}\n");
    }

    static void SB_Append_ByVal(StringBuilder? sb_ptr_byval)
    {
        sb_ptr_byval?.Append("broskies"); //note: [sb_ptr] is cpy of ref
        sb_ptr_byval = null; // so setting to null doesnt make sb null
    }   // and obviously doesnt null the object

    static void SB_Append_ByRef(ref StringBuilder? sb_ptr_byref)
    {
        sb_ptr_byref?.AppendLine("zupskies"); //note: [sb_ptr] is cpy of ref
        //WriteLine($"sb_inbyref: {sb_ptr_byref}");
        sb_ptr_byref = null; // so setting to null doesnt make sb null
    }
}
