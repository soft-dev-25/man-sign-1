using api.Repositories;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class PersonsController : IPersonsController
{
    private readonly IPersonsService _personsService;

    public PersonsController(IPersonsService personsService)
    {
        _personsService = personsService;
    }

    public Task<IActionResult> GetCpr()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetNameAndGender()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetNameAndGenderAndDoB()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetCprAndNameAndGender()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetCprAndNameAndGenderAndDoB()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetAddress()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetPhone()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetSinglePerson()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> GetPersons(int? count)
    {
        throw new NotImplementedException();
    }
}
