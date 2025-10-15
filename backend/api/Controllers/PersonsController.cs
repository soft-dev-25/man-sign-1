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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAddress()
    {
        try
        {
            var personDto = await _personsService.GetAddress();
            if (personDto.Address == null)
            {
                return NotFound("Address not found");
            }

            return Ok(personDto.Address);
        }
        catch (Exception ex)
        {
            // Optionally log the exception here
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                "An unexpected error occurred."
            );
        }
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
