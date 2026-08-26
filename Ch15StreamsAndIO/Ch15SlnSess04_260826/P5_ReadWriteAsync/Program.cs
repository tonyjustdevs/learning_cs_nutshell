using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, P5_ReadWriteAsync!");

        
    }

    public byte[] TPReadBytesExactly(int bytes_count)
    {
        byte[] bytes_buffer = new byte[bytes_count];
        int bytes_read_csum = 0;
        int bytes_read_curr = 0;

        using Stream stream = new FileStream("some_stream.txt", FileMode.Open);
        while (bytes_read_csum<bytes_buffer.Length && bytes_read_curr>0)
        {
            bytes_read_curr = stream.Read(bytes_buffer, bytes_read_csum, bytes_buffer.Length - bytes_read_csum);
            bytes_read_csum += bytes_read_curr;
        }

        return bytes_buffer;
    }


    public byte[] TPReadBytesExactly2(int bytes_count)
    {
        byte[] buffer = new byte[1000];

        int totalBytesRead = 0;
        int bytesRead = 0;

        using Stream s = new FileStream("some.txt", FileMode.Open);

        while (totalBytesRead < buffer.Length)
        {
            
            bytesRead = s.Read(buffer, totalBytesRead, buffer.Length - totalBytesRead);

            if (bytesRead==0)
            {   // [1] throw when byteRead == 0 aka end of stream before buffer is filled
                throw new EndOfStreamException($"stream ended too early");
            }


            totalBytesRead += bytesRead;
        }
        return buffer;
    }
}
