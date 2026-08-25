using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, P10_BinaryReaderBytesArray!");

        using (Stream stream = new FileStream("p10.txt",FileMode.Open))
        {
            byte[] bytes = new BinaryReader(stream).ReadBytes(1000);
            WriteLine("contents: {0}, size: {1}",string.Join(',', bytes), bytes.Length);
            
        }

    }
}
