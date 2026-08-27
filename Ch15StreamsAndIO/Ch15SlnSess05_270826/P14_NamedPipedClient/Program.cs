using System.IO.Pipes;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("hi, P14_NamedPipedClient!");
        var np_client_stream = new NamedPipeClientStream("pipedream");
        WriteLine($"[cli] client created: {np_client_stream}.");
        np_client_stream.Connect();
        WriteLine($"[cli] client connecting to 'pipedream'.");
        WriteLine($"[cli] recieved a byte: {np_client_stream.ReadByte()}");

        np_client_stream.WriteByte(121);
    }
}
