using DesignPatterns.Adapter.BirdExample;
using DesignPatterns.Adapter.StarWarExample;

namespace DesignPatterns.Adapter;

public class Program
{
    public static void Main()
    {
        //var displayService =
        //    new StarWarsCharacterDisplayService(new CharacterFileSourceAdapter(@"..\..\..\People.json"));
        //var result = displayService.ListCharacters();
        //Console.WriteLine(result.Result);
        //displayService = new StarWarsCharacterDisplayService(new StarWarsApiAdapter());
        //result = displayService.ListCharacters();
        //Console.WriteLine(result.Result);

        var sparrow = new Sparrow();
        var birdAdapter = new BirdAdapter(sparrow);
        birdAdapter.Squeak();
    }
}