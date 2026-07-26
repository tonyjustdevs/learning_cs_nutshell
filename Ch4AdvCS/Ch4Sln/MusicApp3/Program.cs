using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday MusicApp3!");

        var m = new MusicPlayer();
        m.CurrentPlayer = new SpotifyPlayer().Play;
        m.Play();

        m.CurrentPlayer = YoutubePlayer.Play;
        m.Play();

        m.CurrentPlayer = () => WriteLine("Anonymous playing...") ;
        m.Play();
    }
}

delegate void DGPlayMethod();

class MusicPlayer
{
    public DGPlayMethod? CurrentPlayer;

    public void Play() 
    {
        CurrentPlayer?.Invoke();   
    }

}
class YoutubePlayer
{
    public static void Play() => WriteLine("Youtube playing...");
}
class SpotifyPlayer
{
    public void Play() => WriteLine("Spotify playing...");
}