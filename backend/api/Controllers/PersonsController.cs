using api.Models;
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
        var addressWrapper = new { Address = addressDto };

        return Ok(addressWrapper);
    }

    [HttpGet("phone")]
    public async Task<IActionResult> GetPhone()
    {
        var phoneNumber = await _personsService.GetPhone();

        return Ok(phoneNumber);
    }

    [HttpGet("person")]
    public async Task<IActionResult> GetSinglePerson()
    {
        var person = await _personsService.GetPerson();

        return Ok(person);
    }

    [HttpGet("persons")]
    public async Task<IActionResult> GetPersons(int? count)
    {
        try
        {
            var persons = await _personsService.GetPersons(count);
            return Ok(persons);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "An unexpected error occurred");
        }
    }
}
