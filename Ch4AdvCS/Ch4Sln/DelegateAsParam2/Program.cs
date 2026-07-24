using System.Threading.Tasks.Dataflow;
using static System.Console;
internal class Program
{
    
    static int Doubler(int a) => a * a;         // 1. Create custom method to be invoked (by delegate): Doubler()
    delegate int DG_IntIntHandler(int a);       // 2. Declare new type int delegate(int): Dg_IntInt_Handler
    static int[] Transform(int[] arr, DG_IntIntHandler dg)
    {

        WriteLine("Applying Transform with: {0}", dg);
        WriteLine("input: {0}", string.Join(",", arr));
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = dg(arr[i]);
        }
        WriteLine("output: {0}", string.Join(",", arr));
        return arr;

        //input: 1,2,3,4,5
        //output: 1,4,9,16,25
    }
    static void Main(string[] args)
    {
        WriteLine("Gday Del-As-Param 2!");
        DG_IntIntHandler dg_doubler = Doubler;  // 3. Create dg_ii_instance
        Transform([1, 2, 3, 4, 5], dg_doubler);

    }


}

// 1. Create custom method to be invoked (by delegate): Doubler()
// 2. Declare new type int delegate(int): Dg_IntInt_Handler
// 3. Create dg_ii_instance
// 4. Add Transform(arr[] arr, delegate dg) method
// 4. run Transform()

