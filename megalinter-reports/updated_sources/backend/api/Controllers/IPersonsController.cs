using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public interface IPersonsController
{
    Task<IActionResult> GetCpr();
    Task<IActionResult> GetNameAndGender();
    Task<IActionResult> GetNameAndGenderAndDoB();
    Task<IActionResult> GetCprAndNameAndGender();
    Task<IActionResult> GetCprAndNameAndGenderAndDoB();
    Task<IActionResult> GetAddress();
    Task<IActionResult> GetPhone();
    Task<IActionResult> GetSinglePerson();
    Task<IActionResult> GetPersons([FromQuery] int? count);
}
