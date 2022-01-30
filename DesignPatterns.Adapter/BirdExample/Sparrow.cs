namespace DesignPatterns.Adapter.BirdExample;

public interface IBird
{
    public void Fly();
    public void MakeSound();
}

public class Sparrow : IBird
{
    public void Fly()
    {
        Console.WriteLine("Flying");
    }

    public void MakeSound()
    {
        Console.WriteLine("Chirp Chirp");
    }
}