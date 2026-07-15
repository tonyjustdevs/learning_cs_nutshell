
using static System.Console;
using System.Collections;
namespace MyTouchyLibrary;

internal class ImASecretInternalClass : IEnumerator
{
    public int Count = 6;
    
    public object Current => Count;

    public bool MoveNext()
    {
        if (Count>0)
        {
            Count--;
            return true;
        }

        Count--;
        return false;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}