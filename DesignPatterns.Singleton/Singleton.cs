namespace DesignPatterns.Singleton;

public sealed class Singleton
{
    private static Singleton? _instance;

    private Singleton()
    {
    }

    public static Singleton Instance => _instance ??= new Singleton();
}