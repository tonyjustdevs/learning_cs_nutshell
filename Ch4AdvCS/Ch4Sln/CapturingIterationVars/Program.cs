using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("gday CapturingIterationVars!");

        // alllocate: create array of Action
        // input: fill in each action i with write(i)
        // output: loop the results 

        Action[] action = new Action[3];
        for (int i = 0; i < action.Length; i++)
        {
            int loopScoped_i = i;
            action[i] = () =>
            {
                Write(loopScoped_i);
            };
        }
        foreach (Action a in action)
        a();
    }
}
