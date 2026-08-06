using static System.Console;

internal class Yolo
{
    public static bool SharedStaticField = false;

    static void Main(string[] args)
    {
        WriteLine("Hello, T4_SharedStaticFieldApp!");

        new Thread(UpdateSharedStaticField).Start();
        UpdateSharedStaticField();

        //new Thread(ShowSharedStaticField).Start();
        //ShowSharedStaticField();
    }

    public static void UpdateSharedStaticField()
    {
        if (!SharedStaticField)
        {
            SharedStaticField = true;
            WriteLine($"SharedStaticField : {SharedStaticField}");
        }
    }
    public static void ShowSharedStaticField() => WriteLine($"SharedStaticField : {SharedStaticField}");

}

