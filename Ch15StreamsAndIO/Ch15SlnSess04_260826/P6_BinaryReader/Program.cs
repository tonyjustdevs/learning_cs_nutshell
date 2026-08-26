using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P6_BinaryReader!");

        //TPBinReadByteFile();
        FileStreamSupportOutput();
    }
    public static void FileStreamSupportOutput()
    {
        using (Stream s = new FileStream("p6.txt", FileMode.Open))
        {
            WriteLine("FileStream supports: ");
            WriteLine($"- s.CanRead: {s.CanRead}");
            WriteLine($"- s.CanWrite: {s.CanWrite}");
            WriteLine($"- s.CanSeek: {s.CanSeek}");
            WriteLine($"- s.CanTimeout: {s.CanTimeout}");

        }
    }




    public static void TPBinReadByteFile()
    {
        using (Stream s = new FileStream("p6.txt", FileMode.Open))
        {
            var br = new BinaryReader(s);
            int byte_no=0;
            try
            {
                while (true)
                {
                    byte_no++;
                    WriteLine($"byte_{byte_no}: {br.ReadByte()}");
                    // byte_1: 116 - t
                    // byte_2: 111 - o
                    // byte_3: 110 - n
                    // byte_4: 121 - y
                    // byte_5: 33  - !
                    // byte_6: 13  - \r
                    // byte_7: 10  - \n
                    //end of file reached: Unable to read beyond the end of the stream.
                }
            }
            catch (Exception ex)
            {
                WriteLine($"end of file reached: {ex.Message}");
            }
        }
    }
    public static void TPBinReadFile()
    {
        using (Stream s = new FileStream("p6.txt", FileMode.Open))
        {
            WriteLine("reading p6.txt");
            var br = new BinaryReader(s);
            byte[] buffer = br.ReadBytes(1000);

            WriteLine($"buffer.Length: {buffer.Length}");
            WriteLine($"hexy: {BitConverter.ToString(buffer)}");
            var buffer_ascii_codes = string.Join(' ', buffer);

            WriteLine($"hexy: {BitConverter.ToString(buffer)}");

            WriteLine($"asc_code: {buffer_ascii_codes}");
        }
    }
    
}
