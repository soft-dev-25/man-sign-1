using api.Models;

namespace api.Repositories;

public interface IPersonsRepository
{
    Task<Postal> GetPostal();
}
