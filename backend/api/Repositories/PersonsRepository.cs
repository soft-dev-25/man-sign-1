using api.DBContext;
using api.Models;

namespace api.Repositories;

public class PersonsRepository(DataContext context) : IPersonsRepository
{
    private readonly Random _random = new();

    public Postal GetPostal()
    {
        //Find all data and return a random postal code
        var postal = context.Postals.ToList();

        var randomPostal = postal[_random.Next(postal.Count)];
        return randomPostal;
    }
}
