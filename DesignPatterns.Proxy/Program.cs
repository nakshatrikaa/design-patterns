namespace DesignPatterns.Proxy;

/// <summary>
/// The 'Subject interface
/// </summary>
public interface IClient
{
    string GetData();
}

/// <summary>
/// The 'RealSubject' class
/// </summary>
public class RealClient : IClient
{
    private readonly string _data;
    public RealClient()
    {
        Console.WriteLine("Real Client: Initialized");
        _data = "Dot Net Tricks";
    }

    public string GetData()
    {
        return _data;
    }
}

/// <summary>
/// The 'Proxy Object' class
/// </summary>
public class ProxyClient : IClient
{
    private readonly RealClient _client = new();
    public ProxyClient()
    {
        Console.WriteLine("ProxyClient: Initialized");
    }

    public string GetData()
    {
        return _client.GetData();
    }
}

/// <summary>
/// Proxy Pattern Demo
/// </summary>
public static class Program
{
    public static void Main(string[] args)
    {
        ProxyClient proxy = new();
        Console.WriteLine("Data from Proxy Client = {0}", proxy.GetData());

        Console.ReadKey();
    }
}