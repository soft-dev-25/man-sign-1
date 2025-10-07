using api.DBContext;
using api.Models.DTOs;
using api.Repositories;

namespace api.Services;

public class PersonsService : IPersonsService
{
    private readonly IPersonsRepository _personsRepository;
    private readonly DataContext _context;

    public PersonsService(IPersonsRepository personsRepository, DataContext dataContext)
    {
        _personsRepository = personsRepository;
        _context = dataContext;
    }

    public Task<string> GetCpr()
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetNameAndGender()
    {
        throw new NotImplementedException();
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
