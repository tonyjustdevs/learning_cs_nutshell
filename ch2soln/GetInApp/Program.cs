using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello Sizes!");                                
        WriteLine($"sizeof(short): {sizeof(short)   } (actual: 2)"); 
        WriteLine($"sizeof(char): {sizeof(char)     } (actual: 2)"); 
        WriteLine($"sizeof(double): {sizeof(double) } (actual: 8)"); 
        WriteLine($"sizeof(float): {sizeof(float)   } (actual: 4)"); 
        WriteLine($"sizeof(int): {sizeof(int)       } (actual: 4)"); 
        WriteLine($"sizeof(long): {sizeof(long)     } (actual: 8)"); 

    }

}

struct ConSession // says 32-bytes
{
    short open_hour, open_min;     // 2, 2 = 4
    short close_hour, close_min;   // 2, 2 = 4
    int open, close;               // 4, 4 = 8
    short align[7];                // 2 
};
//---
struct ConSessions
{
    //---
    ConSession quote[3];                    // quote sessions
    ConSession trade[3];                    // trade sessions
                                            //---
    int quote_overnight;             // internal data
    int trade_overnight;             // internal data
    int reserved[2];                 // reserved


