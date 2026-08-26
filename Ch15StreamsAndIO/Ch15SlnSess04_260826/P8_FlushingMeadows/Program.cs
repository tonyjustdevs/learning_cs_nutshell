using static System.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("xin chao, P8_FlushingMeadows!");
        //WriteToFileViaFlush(); working
        await WriteToFileViaFlush2();
    }

    public static async Task WriteToFileViaFlush2()
    {
        using (Stream s = new FileStream("p8_toilet.txt",
        FileMode.Create,
        FileAccess.ReadWrite,
        FileShare.ReadWrite))
        {
            byte[][] buffer = [
                //[116, 111, 110, 121, 13, 10],
                [108, 117, 110, 97, 13, 10],
                [105, 115, 13, 10],
                [99, 111, 111, 108, 33, 13, 10],
            ];

            foreach (var byte_arr in buffer)
            {
                s.Write(byte_arr, 0, byte_arr.Length);
                WriteLine("writing to file...");
                s.Flush();
                await Task.Delay(2000);
            }
        }
    }
    public static void WriteToFileViaFlush()
    {
        // [1] do some writes
        // [2] check file?? (shouldnt appear yet
        // [3] flush
        // [4] confirm written to file
        using (Stream s = new FileStream("p8_toilet.txt",
        FileMode.Create,
        FileAccess.ReadWrite,
        FileShare.ReadWrite))
        {
            byte[] buffer = [116, 111, 110, 121, 13, 10];
            s.Write(buffer, 0, buffer.Length);

            WriteLine("press any key to flush ...");
            ReadLine();
            s.Flush();
            s.Write(new byte[4] { 105, 115, 13, 10 }, 0, 4);

            WriteLine("press any key to flush ...");
            ReadLine();
            s.Flush();
            s.Write(new byte[7] { 99, 111, 111, 108, 33, 13, 10 }, 0, 7);

            WriteLine("press any key to end");
            ReadLine();
        }
    }
}
