namespace MyTouchyLibrary;

public static class InternalClassRevealerCls
{
    public static object GetSecretClass() => new ImASecretInternalClass();
}
