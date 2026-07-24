using System.ComponentModel.Design;
using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {

        string? playmeth=null!;
        while (playmeth is null)
        {
            WriteLine("\nChoose Play Method: 'stream' or 'mp3' or 'exit'");
            playmeth = ReadLine()?.ToLowerInvariant();
            
            if (playmeth=="stream")
            {
                MusicPlayer.PlayMusic(StreamingService.PlayStream);
                break;
            }
            else if (playmeth == "mp3")
            {
                MusicPlayer.PlayMusic(Mp3.PlayMp3);
                break;
            }
            else if (playmeth == "exit")
            {
                break;
            }
            playmeth = null;
        }

        Thread.Sleep(1000);
        WriteLine("\nExiting Program. Goodbye.");

    }


}
class Mp3
{
    public static void PlayMp3() 
    {
        WriteLine("Mp3 started playing...");
    }
}

class StreamingService
{
    public static void PlayStream() 
    {
        WriteLine("Starting streaming service...");
    }

}


class StartMusic
{
    void PlayMp3() { } // rigid

}
    //void Play(PlayMethod pm) { }

delegate void PlayMethod();

class MusicPlayer
{
    public static void PlayMusic(PlayMethod pm)
    {
        WriteLine("Started MusicPlayer.PlayMusic(...)");
        Thread.Sleep(1000);
        pm();
        Thread.Sleep(2000);
        WriteLine("song finished...");
    }
}
