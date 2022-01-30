namespace DesignPatterns.Adapter.StarWarExample;

public interface ICharacterSourceAdapter
{
    Task<IEnumerable<Person>> GetCharacters();
}