namespace DesignPatterns.Adapter.BirdExample;

public interface IToyDuck
{
    public void Squeak();
}

public class PlasticToyDuck : IToyDuck
{
    public void Squeak()
    {
        Console.WriteLine("Squeak");
    }
}