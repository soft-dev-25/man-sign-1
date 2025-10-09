using api.Models.DTOs;

namespace api.Services;

public interface IJsonService
{
    Task<Person> GetRandomPersonFromJson();
}
