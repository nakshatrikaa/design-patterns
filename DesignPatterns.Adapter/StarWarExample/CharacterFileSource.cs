using Newtonsoft.Json;

namespace DesignPatterns.Adapter.StarWarExample;

public class CharacterFileSource
{
    public async Task<List<Person>> GetCharactersFromFile(string filename)
    {
        var characters = JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(filename));

        return characters;
    }
}

public class CharacterFileSourceAdapter : ICharacterSourceAdapter
{
    private readonly CharacterFileSource _characterFileSource = new();
    private readonly string _fileName;

    public CharacterFileSourceAdapter(string fileName)
    {
        _fileName = fileName;
    }

    public async Task<IEnumerable<Person>> GetCharacters()
    {
        return await _characterFileSource.GetCharactersFromFile(_fileName);
    }
}