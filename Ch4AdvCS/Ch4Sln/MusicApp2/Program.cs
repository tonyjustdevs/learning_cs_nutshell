using System.Reflection;
using System.Reflection.PortableExecutable;
using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Welcome to MusicApp2");

`        // compile-time:
        // - compilter writes meta-data tables to the assemblies (dll/exe)
        // - [1] source code to Intermediate Language (IL) (e.g.newobj MusicPlayer::.ctor)

        // [2a] [why not save machine code?] bc machine-code depends on:
        // - cpu arch (x64/arm64), .NET runtime version, opt settings, runtime info
        // run-time (exe starts, OS loads CLR, CLR loads your assembly):
        // CLR: 
        // - [1]  reads all meta-data tables from ass (like reading a json file)
        // - [1a] - CLR now knows existence of each type: # of constructors, flds, meths etc
        // - but hasnt prepared them??
        // - [1b]  Verfiy IL: [not sure why compiler wasnt enough? WIP review]

        // [2] Start at Main
        // JIT-Compiler
        // - CPU cannot understand IL: IL is Assembly language for the CLR.
        // - CPU does not execute IL: CLR executes IL.
        // - CLR contains another compiler: JIT Compiler
        // - Just-In-Time Compiler: waits til method is actually needed.
        // [2] e.g. Program contains: Main(), PlayMusic(), etc... are still IL
        // - Program starts and reaches Main()
        // - CLR notices Main has not bee compiled, JIT compiles it there and then.
        // - ie IL -> Machine Code: Main now is actual CPU instructions
        // - Store native machine code in this process's memory.
        // - Executable Memory:  main() machine code
        // - Main() machine code is executed

        // - [3] reach MusicPlayer m = new();
        // - is not prepared yet (aka no runttime infomation), CLR creates runtime structure
        // - Method Table: MusicPLayer...currentplayer: #, fieldoffset, objectsize=#,
        // - methods:Play .ctor, inheritance: Object, AKA TYPE INFORMATION
        // - [3]  CLR Builds "Internal Runtime Structures" on demand (lazy laoding / lazily)
        // - [3a] - RunTimeType created per Type
        // - [3b] - Store in big dict{ k: RunTypeName (e.g. MusicPlayer, Song, etc), v: RunTimeType }
        //        - After first lookup, CLR has {MusicPlayer->Runtime rep} ready
        // - [3c] - RuntimeType stores ObjectSize <-> allocates n-bytes (no flds searching)

        // - [4]  need object size <-> MethodTable says 24 bytes <-> allocate 24 bytes
        // - [4a] Heap object created:

        //  +----------------------+
        //  | Object Header        |
        //  +----------------------+
        //  | MethodTable Pointer  | -----+
        //  +----------------------+      |
        //  | CurrentPlayer = null |      |
        //  +----------------------+      |
        //                                |
        //                                |
        //                      +---------+
        //                      |
        //                      ▼
        //              MusicPlayer MethodTable

        // - [5]  Constructor: .ctor: il -> jit - machine code

        // IF NOT ABOVE:
        // - [3b] - no dict means, each instatantion (new MusicPlayer()) leads to:
        // - search type, find MusicPlayer, calc size, calc-offsets, find constuctors, allocat object
        // - 
        // 1.Allocate memory
        // 2.Zero all fields
        // 3.Write object header
        // 4.Write MethodTable pointer
        // 5.Call MusicPlayer::.ctor()
        // 6.Return reference
        m.CurrentPlayer = Mp3Player;

        m.Play();

    }

    static void Mp3Player()
    {
        WriteLine("mp3player started playing...");
    }
}
delegate void PlayerDG();

class MusicPlayer
{
    public PlayerDG? CurrentPlayer;
    
    public void Play()
    {
        CurrentPlayer?.Invoke();
    }

}
