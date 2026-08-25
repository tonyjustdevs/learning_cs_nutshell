using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P9_AThousandByteStream!");

        
    }

    static void ReadAThousandBytes()
    {
        byte[] data_buffer = new byte[1000];
        int chunk_size = 0;
        int bytes_read = 0;

        using Stream stream = new FileStream("a_big_file.txt", FileMode.Open) ;

        while (bytes_read<data_buffer.Length && chunk_size>0)
        {
            // iteration 0: read 5 bytes,idx: 0, 1000-0
            // [x, x, x, x, x, ...]
            // [x, x, x, x, x, ...]

            // iteration 1: read 10 bytes,idx:5, 1000-5)
            // iteration 2: read 10 bytes,idx:5, 1000-5)

            chunk_size = stream.Read(data_buffer, bytes_read,data_buffer.Length - bytes_read);
            bytes_read += chunk_size;           
        }
    }
}
