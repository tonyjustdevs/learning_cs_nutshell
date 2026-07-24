using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Gday MusicApp!");
        var player = new MusicPlayer();

        player.CurrentPlayer = PlayMp3;     // 2. Plug in MP3 playback
        player.Play();   

                            
        player.CurrentPlayer = PlayStream;  // 3. Later: 
        player.Play();                      // - plug in [streaming] wout MusicPlayer cls chging
    }

    static void PlayMp3() => WriteLine("mp3 is playing...");
    static void PlayStream() => WriteLine("stream is playing...");
}

delegate void DG_PlayMethod();
class MusicPlayer
{
    public DG_PlayMethod? CurrentPlayer;

    public void Play() 
    {
        
        CurrentPlayer?.Invoke();
    }
}