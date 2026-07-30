using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, RecordsApp!");
        var soco = new Coordinates(10.81, 106.71);

        var (lat, lon) = soco;
        WriteLine($"lat: {lat}");
        WriteLine($"lon: {lon}");
    }
}


record Coordinates(double Latitude, double Longitude);