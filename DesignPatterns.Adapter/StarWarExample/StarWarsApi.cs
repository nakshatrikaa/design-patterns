using Newtonsoft.Json;

namespace DesignPatterns.Adapter.StarWarExample;

public class StarWarsApi
{
    private const string Url = "https://swapi.dev/api/people";

    public async Task<List<Person>> GetCharacters()
    {
        using var client = new HttpClient();
        var result = await client.GetStringAsync(Url);
        var people = JsonConvert.DeserializeObject<ApiResult<Person>>(result)?.Results;

        return people;
    }
}