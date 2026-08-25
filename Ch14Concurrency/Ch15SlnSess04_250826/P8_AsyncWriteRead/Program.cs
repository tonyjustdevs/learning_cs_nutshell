using System.Text;
using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("hi, P8_AsyncWriteRead!");
        await WriteAsyncTP();
        
        await Task.Delay(2000);
        
        await ReadAsyncTP();
    
        WriteLine("end...");

    }

    static async Task WriteAsyncTP()
    {
        using (Stream stream = new FileStream("p8.txt", FileMode.Create))
        {
            byte[] bytes_buffer = [116, 111, 110, 121, 33, 10];
            await stream.WriteAsync(bytes_buffer);
            WriteLine("write to p8.txt completed");

        }
    }

    static async Task ReadAsyncTP()
    {
        using (Stream stream = new FileStream("p8.txt", FileMode.Open))
        {
            byte[] bytes_buffer = new byte[50];
            await stream.ReadAsync(bytes_buffer, 0, bytes_buffer.Length);
            WriteLine($"bytes_buffer_hexy: {Convert.ToHexString(bytes_buffer)}");
            WriteLine($"bytes_buffer_gstr: {ASCIIEncoding.ASCII.GetString(bytes_buffer,0, bytes_buffer.Length)}");
        }
    }

}