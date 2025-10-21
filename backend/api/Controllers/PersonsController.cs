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
    public async Task<IActionResult> GetNameAndGenderAndDoB()
    {
        var nameGenderDoB = await _personsService.GetNameAndGenderAndDoB();

        return Ok(nameGenderDoB);
    }

    [HttpGet("cpr-name-gender")]
    public async Task<IActionResult> GetCprAndNameAndGender()
    {
        var cprNameAndGender = await _personsService.GetCprAndNameAndGender();

        return Ok(cprNameAndGender);
    }

    [HttpGet("cpr-name-gender-dob")]
    public async Task<IActionResult> GetCprAndNameAndGenderAndDoB()
    {
        var cprAndNameAndGenderAndDoB = await _personsService.GetCprAndNameAndGenderAndDoB();

        return Ok(cprAndNameAndGenderAndDoB);
    }

    [HttpGet("address")]
    public async Task<IActionResult> GetAddress()
    {
        var addressDto = await _personsService.GetAddress();
            
        return Ok(addressDto);
    }

    [HttpGet("phone")]
    public async Task<IActionResult> GetPhone()
    {
        var phoneNumber = await _personsService.GetPhone();

        return Ok(phoneNumber);
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
