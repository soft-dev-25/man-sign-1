using api.DBContext;
using api.Models.DTOs;
using api.Repositories;

namespace api.Services;

public class PersonsService : IPersonsService
{
    private readonly DataContext _context;
    private readonly IJsonService _jsonService;
    private readonly IPersonsRepository _personsRepository;

    public PersonsService(
        IPersonsRepository personsRepository,
        DataContext dataContext,
        IJsonService jsonService
    )
    {
        _personsRepository = personsRepository;
        _context = dataContext;
        _jsonService = jsonService;
    }

    public async Task<PersonDTO> GetCpr()
    {
        var person = await _jsonService.GetRandomPersonFromJson();
        person.CreateCpr();
        return new PersonDTO { Cpr = person.Cpr };
    }

    public async Task<PersonDTO> GetNameAndGender()
    {
        var person = await _jsonService.GetRandomPersonFromJson();
        return new PersonDTO
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Gender = person.Gender
        };
    }

    public Task<PersonDTO> GetNameAndGenderAndDoB()
    {
        throw new NotImplementedException();
    }

    public Task<PersonDTO> GetCprAndNameAndGender()
    {
        throw new NotImplementedException();
    }

    public Task<PersonDTO> GetCprAndNameAndGenderAndDoB()
    {
        throw new NotImplementedException();
    }

    public Task<PersonDTO> GetAddress()
    {
        throw new NotImplementedException();
    }

    public async Task<PersonDTO> GetPhone()
    {
        var person = await _jsonService.GetRandomPersonFromJson();
        person.CreatePhoneNumber();
        return new PersonDTO { PhoneNumber = person.PhoneNumber };
    }

    public Task<List<PersonDTO>> GetPersons(int? count = 1)
    {
        throw new NotImplementedException();
    }
}