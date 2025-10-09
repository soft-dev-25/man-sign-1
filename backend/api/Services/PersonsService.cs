using System.Text.Json;
using api.DBContext;
using api.Models.DTOs;
using api.Repositories;

namespace api.Services;

public class PersonsService : IPersonsService
{
    private readonly DataContext _context;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly IPersonsRepository _personsRepository;

    public PersonsService(IPersonsRepository personsRepository, DataContext dataContext,
        JsonSerializerOptions jsonOptions)
    {
        _personsRepository = personsRepository;
        _context = dataContext;
        _jsonOptions = jsonOptions;
    }

    public Task<string> GetCpr()
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetNameAndGender()
    {
        var json = File.ReadAllText("Data/person-names.json");

        var peopleList = JsonSerializer.Deserialize<List<Person>>(json, _jsonOptions);

        if (peopleList == null || peopleList.Count == 0)
        {
            throw new Exception("No people found");
        }

        var random = new Random();
        var randomPerson = peopleList[random.Next(0, peopleList.Count)];
        return Task.FromResult(randomPerson);
    }

    public Task<Person> GetNameAndGenderAndDoB()
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetCprAndNameAndGender()
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetCprAndNameAndGenderAndDoB()
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetAddress()
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetPhone()
    {
        throw new NotImplementedException();
    }

    public Task<List<Person>> GetPersons(int? count = 1)
    {
        throw new NotImplementedException();
    }
}