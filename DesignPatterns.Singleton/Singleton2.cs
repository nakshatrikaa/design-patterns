namespace DesignPatterns.Singleton;

public sealed class Singleton2
{
    private static Singleton2? _instance;
    private static readonly object InstanceLock = new();

    private Singleton2()
    {
    }

    public static Singleton2 Instance
    {
        get
        {
            lock (InstanceLock)
            {
                return _instance ??= new Singleton2();
            }
        }
    }
}