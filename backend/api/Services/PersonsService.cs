using api.DBContext;
using api.Models;
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
            Gender = person.Gender,
        };
    }

    public async Task<PersonDTO> GetNameAndGenderAndDoB()
    {
        var person = await _jsonService.GetRandomPersonFromJson();
        person.CreateBirthdate();

        var dto = new PersonDTO
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Gender = person.Gender,
        };
        dto.SetBirthDate(person.BirthDate);

        return dto;
    }

    public async Task<PersonDTO> GetCprAndNameAndGender()
    {
        var person = await _jsonService.GetRandomPersonFromJson();
        person.CreateCpr();

        var dto = new PersonDTO
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Gender = person.Gender,
            Cpr = person.Cpr,
        };

        return dto;
    }

    public async Task<PersonDTO> GetCprAndNameAndGenderAndDoB()
    {
        var person = await _jsonService.GetRandomPersonFromJson();
        person.CreateCpr();

        var dto = new PersonDTO
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Gender = person.Gender,
            Cpr = person.Cpr,
        };
        dto.SetBirthDate(person.BirthDate);

        return dto;
    }

    public async Task<AddressDTO> GetAddress()
    {
        var postal = await _personsRepository.GetPostal();
        var address = Address.GenerateFakeAddress();

        var dto = new AddressDTO
        {
            Door = address.Door,
            Number = address.Number,
            Street = address.Street,
            TownName = postal.TownName,
            PostalCode = postal.PostalCode,
        };
        dto.SetFloor(address.Floor);

        return dto;
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
