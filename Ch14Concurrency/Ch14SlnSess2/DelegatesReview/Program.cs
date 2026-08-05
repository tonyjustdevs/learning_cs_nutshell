using static System.Console;
internal class Program
{
    delegate void DG_Void();
    static void Void_MG1() => WriteLine("i am assignable...");

    static void Main(string[] args)
    {
        WriteLine("Hello, DelegatesReview!");
        //DG_Void void_delegate_instance = Void_MG1;
        //void_delegate_instance();

        //ThreadStart thread_start_instance = Void_MG1;
        //thread_start_instance();

        //Thread t1 = new Thread(Void_MG1);
        DoMeth(42);
        ThreadStart action = Void_MG1;

        var t = new Thread(action);
    }
    static void DoMeth(int x) { }
    static void DoThread(ThreadStart ts) { }

}
