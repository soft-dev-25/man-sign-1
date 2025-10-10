using api.DBContext;
using api.Models;
using api.Models.DTOs;
using api.Repositories;

namespace api.Services;

public class PersonsService : IPersonsService
{
    private readonly IPersonsRepository _personsRepository;
    private readonly DataContext _context;
    private readonly IJsonService _jsonService;

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
        return new PersonDTO() { Cpr = person.Cpr };
    }

    public Task<PersonDTO> GetNameAndGender()
    {
        throw new NotImplementedException();
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
        var postal = _personsRepository.GetPostal();
        var fakeAddress = Address.GenerateFakeAddress();
        fakeAddress.PostalCode = postal.PostalCode;
        fakeAddress.TownName = postal.TownName;
        return Task.FromResult(new PersonDTO() { Address = fakeAddress });
    }

    public Task<PersonDTO> GetPhone()
    {
        throw new NotImplementedException();
    }

    public Task<List<PersonDTO>> GetPersons(int? count = 1)
    {
        throw new NotImplementedException();
    }
}
