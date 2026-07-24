using System.Text;
using static System.Console;
namespace ParamTypesApp2;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello ParamTypes2");
        var sb = new StringBuilder();

        SBAppend_ByVal(sb, "first-line...");
        WriteLine($"[1] sb: '{sb}' (exp: '[first]')");

        //SBAppend_ByRef(ref sb, "[second]");
        //WriteLine($"[2] sb: '{sb}' (exp: '' ie null)");
        SBAppend_ByRef(sb, "[second]");
        WriteLine($"[2] sb: '{sb}' (exp: '' ie null)");

    }

    public static void SBAppend_ByVal(StringBuilder? sb_byval,string txt) 
    {
        sb_byval?.Append(txt);
        sb_byval = null;
    }

    public static void SBAppend_ByRef(ref StringBuilder? sb_byref_ptr, string txt)
    {
        sb_byref_ptr?.Append(txt); // outside sb->"[first][second]"
        sb_byref_ptr = null; //outside sb -> null
    }
}


