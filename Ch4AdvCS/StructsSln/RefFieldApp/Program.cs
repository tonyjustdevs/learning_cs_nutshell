using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, RefFieldApp!");

        int x = 10;
        // 'x' is a int variable in the stack
        // 'x' value: 10

        ref int y = ref x;
        // 'y' is a int variable in the stack
        // 'y' value: ref to x

        // stack
        // -----
        // x, y  
        // +----+
        // |10  |
        // +----+
        // comments:
        // - if 'x' is a persons name,
        // - if 'y' is a persons nickname,
        // - its the same person!

    }
}
