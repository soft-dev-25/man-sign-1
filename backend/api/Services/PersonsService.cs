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

    public async Task<PersonDTO> GetPerson()
    {
        var person = await _jsonService.GetRandomPersonFromJson();
        var addressDto = await GetAddress();
        person.CreatePhoneNumber();
        person.CreateCpr();

        var personDto = _personToDTO(person);
        personDto.Address = addressDto;

        return personDto;
    }

    public async Task<List<PersonDTO>> GetPersons(int? count = 1)
    {
        if (!count.HasValue)
        {
            throw new ArgumentException("Count cannot be null");
        }
        else if (count > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Too many persons requested");
        }
        else if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Provide a positive count");
        }

        var persons = new List<PersonDTO>();

        for (var i = 0; i < count.Value; i++)
        {
            var person = await GetPerson();
            persons.Add(person);
        }

        return persons;
    }

    private PersonDTO _personToDTO(Person person)
    {
        var dto = new PersonDTO();

        if (!string.IsNullOrEmpty(person.Cpr))
            dto.Cpr = person.Cpr;

        if (!string.IsNullOrEmpty(person.FirstName))
            dto.FirstName = person.FirstName;

        if (!string.IsNullOrEmpty(person.LastName))
            dto.LastName = person.LastName;

        if (!string.IsNullOrEmpty(person.Gender))
            dto.Gender = person.Gender;

        if (person.BirthDate != null)
            dto.SetBirthDate(person.BirthDate);

        if (person.Address != null)
        {
            dto.Address = new AddressDTO
            {
                Door = person.Address.Door,
                Number = person.Address.Number,
                Street = person.Address.Street,
                TownName = person.Address.TownName,
                PostalCode = person.Address.PostalCode,
            };
        }

        if (!string.IsNullOrEmpty(person.PhoneNumber))
            dto.PhoneNumber = person.PhoneNumber;

        return dto;
    }
}
