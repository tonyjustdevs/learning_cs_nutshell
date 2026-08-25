using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, P7_StreamWriteReadEncoding!");

        //using (Stream stream = new FileStream("p7.txt", FileMode.Create)) 
        //{
        //    WriteLine("writing to p7.txt");
        //    stream.WriteByte(121);
        //    stream.WriteByte(110);
        //    stream.WriteByte(111);
        //    stream.WriteByte(116);
        //    stream.WriteByte(33);
        //    stream.WriteByte(10);
        //}
        using (Stream stream = new FileStream("p7.txt", FileMode.Open))
        {
            byte[] bytes = [69, 42, 12, 6, 88];

            WriteLine($"# of bytes read written to buffer: {stream.Read(bytes, 0, bytes.Length)}");
            WriteLine("buffer:\n");
            foreach (var b in bytes) Write($"{b} ");

        }


    }
}

