using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class PersonsController : ControllerBase, IPersonsController
{
    private readonly IPersonsService _personsService;

    public PersonsController(IPersonsService personsService)
    {
        _personsService = personsService;
    }

    [HttpGet("cpr")]
    public async Task<IActionResult> GetCpr()
    {
        var person = await _personsService.GetCpr();

        return Ok(person);
    }

    [HttpGet("name-gender")]
    public async Task<IActionResult> GetNameAndGender()
    {
        var nameGender = await _personsService.GetNameAndGender();

        return Ok(nameGender);
    }

    [HttpGet("name-gender-dob")]
    public Task<IActionResult> GetNameAndGenderAndDoB()
    {
        throw new NotImplementedException();
    }

    [HttpGet("cpr-name-gender")]
    public Task<IActionResult> GetCprAndNameAndGender()
    {
        throw new NotImplementedException();
    }

    [HttpGet("cpr-name-gender-dob")]
    public Task<IActionResult> GetCprAndNameAndGenderAndDoB()
    {
        throw new NotImplementedException();
    }

    [HttpGet("address")]
    public Task<IActionResult> GetAddress()
    {
        throw new NotImplementedException();
    }

    [HttpGet("phone")]
    public async Task<IActionResult> GetPhone()
    {
        var phone = await _personsService.GetPhone();

        return Ok(phone);
    }

    [HttpGet("person")]
    public Task<IActionResult> GetSinglePerson()
    {
        throw new NotImplementedException();
    }

    [HttpGet("persons")]
    public Task<IActionResult> GetPersons(int? count)
    {
        throw new NotImplementedException();
    }
}