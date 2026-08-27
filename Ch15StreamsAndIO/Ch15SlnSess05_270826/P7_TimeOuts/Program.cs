using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, P7_TimeOuts!");

        string file_name = "p7.txt";
        var contents_array = File.ReadAllLines(file_name);
        
        var contents_bytes = File.ReadAllBytes(file_name);
        WriteLine("\n\nReadAllLines of p7.txt: ");
        foreach (var item in contents_array) WriteLine($"- {item}");

        WriteLine("\n\nReadAllBytes of p7.txt: ");
        foreach (var item in contents_bytes) Write($"{item} ");

        var contents_str = File.ReadAllText(file_name);
        WriteLine("\n\nReadAllText of p7.txt: ");
        WriteLine(contents_str);

        string[] str_array = {"hes", "a","\r\n", "barca", "fan" };
        File.AppendAllText(file_name,string.Join(" ", str_array));
    }
}
