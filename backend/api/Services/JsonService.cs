using System.Text.Json;
using api.Models.DTOs;

namespace api.Services;

public class JsonService : IJsonService
{
    private readonly string _jsonPath;
    private readonly Random _random = new Random();

    public JsonService()
    {
        var jsonPath = Path.Combine("Data", "person-names.json");
        if (!File.Exists(jsonPath))
        {
            throw new FileNotFoundException($"Person names file not found at {jsonPath}");
        }

        _jsonPath = jsonPath;
    }

    public async Task<Person> GetRandomPersonFromJson()
    {
        var jsonContent = await File.ReadAllTextAsync(_jsonPath);

        // Create a wrapper class for the JSON structure
        var wrapper = JsonSerializer.Deserialize<PersonWrapper>(
            jsonContent,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        if (wrapper?.Persons == null || wrapper.Persons.Count == 0)
        {
            throw new InvalidOperationException("No persons found in the JSON file");
        }

        var randomIndex = _random.Next(0, wrapper.Persons.Count);
        return wrapper.Persons[randomIndex];
    }
}

internal class PersonWrapper
{
    public List<Person> Persons { get; set; } = new();
}
