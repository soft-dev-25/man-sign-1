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
    public Task<IActionResult> GetNameAndGender()
    {
        throw new NotImplementedException();
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

            return Ok(personDto.Address.ToString());
        }
        catch (Exception ex)
        {
            // Optionally log the exception here
            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
        }
    }

    [HttpGet("phone")]
    public Task<IActionResult> GetPhone()
    {
        throw new NotImplementedException();
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
