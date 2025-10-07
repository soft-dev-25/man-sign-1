using api.Models.DTOs;

namespace api.Services;

public interface IPersonsService
{
    Task<string> GetCpr();
    Task<Person> GetNameAndGender();
    Task<Person> GetNameAndGenderAndDoB();
    Task<Person> GetCprAndNameAndGender();
    Task<Person> GetCprAndNameAndGenderAndDoB();
    Task<Person> GetAddress();
    Task<Person> GetPhone();
    Task<List<Person>> GetPersons(int? count);
}
