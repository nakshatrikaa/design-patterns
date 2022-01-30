namespace DesignPatterns.Adapter.BirdExample;

public class BirdAdapter : IToyDuck
{
    private readonly IBird _bird;

    public BirdAdapter(IBird bird)
    {
        _bird = bird;
    }

    public void Squeak()
    {
        _bird.MakeSound();
    }
}