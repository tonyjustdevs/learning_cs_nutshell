using System.IO.Pipes;
using static System.Console;    

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, P13_NamedPipedServer!");

        using var np_server_stream = new NamedPipeServerStream("pipedream");
        WriteLine($"[svr] create np_server_stream 'pipedream': {np_server_stream}.");
        WriteLine($"[svr] waiting for connection: {np_server_stream}.");
        np_server_stream.WaitForConnection();

        np_server_stream.WriteByte(116);

        WriteLine($"[svr] received byte: {np_server_stream.ReadByte()}.");
        
    }
}
