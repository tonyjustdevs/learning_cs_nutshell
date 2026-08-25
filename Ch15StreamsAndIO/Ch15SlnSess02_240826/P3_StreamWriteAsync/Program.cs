using static System.Console;
internal class Program
{
    static async Task Main(string[] args)
    {
        WriteLine("hi, P3_StreamWriteAsync!");
        try
        {
            await TPWriteAsync();
            WriteLine("File is ready!");
        }
        catch (Exception ex)
        {
            WriteLine($"error caught: {ex.Message} [{ex.GetType()}]");
        }
    }

    static async Task TPWriteAsync()
    {
        using (Stream stream = new FileStream("test3.txt",FileMode.Create)) 
        {
            byte[] bytes = { 116, 111, 110, 121, 10 };
            
            await stream.WriteAsync(bytes, 0, bytes.Length);

            WriteLine("\n\nstream.Position: {0}", stream.Position);
            for (int i = 0; i < bytes.Length; i++)
            {
                Write($"{bytes[i]} ");
                bytes[i] = 0;
            }
            WriteLine("\nset Bytes array to Zero: ");
            foreach (var b in bytes) Write($"{b} ");

            WriteLine("\nset stream.Position to Zero: ");
            stream.Position = 0;
            WriteLine("\n\n# of bytes read: {0}", await stream.ReadAsync(bytes, 0, bytes.Length));
            foreach (var b in bytes) Write($"{b} ");
            


        }
    }
}
