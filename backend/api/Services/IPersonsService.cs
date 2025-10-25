using api.Models.DTOs;

namespace api.Services;

public interface IPersonsService
{
    Task<PersonDTO> GetCpr();
    Task<PersonDTO> GetNameAndGender();
    Task<PersonDTO> GetNameAndGenderAndDoB();
    Task<PersonDTO> GetCprAndNameAndGender();
    Task<PersonDTO> GetCprAndNameAndGenderAndDoB();
    Task<AddressDTO> GetAddress();
    Task<PersonDTO> GetPhone();
    Task<PersonDTO> GetPerson();
    Task<List<PersonDTO>> GetPersons(int? count);
}
