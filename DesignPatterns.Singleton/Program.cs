namespace DesignPatterns.Singleton;

public static class Program
{
    public static void Main()
    {
        var singleton = Singleton.Instance;
        var single = Singleton2.Instance;

        var s3 = Singleton3.Instance;
        Console.WriteLine(s3.Name + " : " + s3.IPAddress);

        var copy = Singleton3.Instance;

        Console.WriteLine(s3.GetHashCode());
        Console.WriteLine(copy.GetHashCode());

        //Console.WriteLine(single.GetHashCode());
        //Console.WriteLine(singleton.GetHashCode());
    }
}
