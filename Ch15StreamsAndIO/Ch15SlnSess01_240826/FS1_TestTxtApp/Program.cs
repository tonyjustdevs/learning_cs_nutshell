using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, FS1_TestTxtApp!");

        using (Stream stream = new FileStream("test1.txt", mode: FileMode.Create)) 
        {
            WriteLine("\ns.WriteByte(x): 116, 111, 110, 121, 10 to stream");
            stream.WriteByte(116); 
            stream.WriteByte(111); 
            stream.WriteByte(110); 
            stream.WriteByte(121);
            stream.WriteByte(10);
            // 0100-0000
            //stream.WriteByte(11);

            WriteLine("\ns.Write({},0,len): {77, 65, 84, 69, 89 } to stream");
            byte[] byte_block = { 77, 65, 84, 69, 89 };
            stream.Write(byte_block, 0, byte_block.Length);

            WriteLine($"\nstream.Length: {stream.Length}");
            WriteLine($"stream.Position: {stream.Position}");

            stream.Position = 0;
            WriteLine($"\nset to stream.Position to 0");
            WriteLine($"stream.Position: {stream.Position} (exp: 0)");
            WriteLine($"\nstream.ReadByte(): {stream.ReadByte()} (exp: 116 't')");
            WriteLine($"stream.Position: {stream.Position}  (exp: 1)");
            WriteLine($"\nstream.ReadByte(): {stream.ReadByte()} (exp: 111 'o')");
            WriteLine($"stream.Position: {stream.Position}  (exp: 2)");

            WriteLine("\nread from stream to block_array:");
            ;
            int bytes_read = stream.Read(byte_block, 0, byte_block.Length);
            WriteLine($"bytes_read: {bytes_read} (exp: 5)");
            Write($"block_in_byte_block (exp: '110,121,10,77,65):");

            foreach (var block in byte_block) {
                long pos = stream.Position;
                WriteLine($"- {block}"); 
            }
            WriteLine($"stream.Position: {stream.Position}  (exp: )");



            //bytes_read = stream.Read(byte_block, 0, byte_block.Length);
            //WriteLine($"bytes_read: {bytes_read} (exp: 3)");
            //Write($"block_in_byte_block (exp: 'TEY' or '84,69,89'):");
            //foreach (var block in byte_block)
            //{
            //    long pos = stream.Position;
            //    WriteLine($"- {block}");
            //}

        }
        

    }
}
