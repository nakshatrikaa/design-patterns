namespace DesignPatterns.Singleton;

public sealed class Singleton3
{
    private static readonly Lazy<Singleton3> Lazy = new(()=> new Singleton3());

    public string Name { get; }

    public string IPAddress { get; }
    private Singleton3()
    {
        Name = "Server";
        IPAddress = "196.0.0.1";
    }

    public static Singleton3 Instance => Lazy.Value;
}