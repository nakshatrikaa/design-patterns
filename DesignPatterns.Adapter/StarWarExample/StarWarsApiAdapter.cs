namespace DesignPatterns.Adapter.StarWarExample;

internal class StarWarsApiAdapter : ICharacterSourceAdapter
{
    private readonly StarWarsApi _starWarsApi = new();

    public async Task<IEnumerable<Person>> GetCharacters()
    {
        return await _starWarsApi.GetCharacters();
    }
}