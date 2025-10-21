using api.DBContext;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class PersonsRepository(DataContext context) : IPersonsRepository
{
    private readonly Random _random = new();

    public async Task<Postal> GetPostal()
    {
        var postal = await context.Postals.ToListAsync();

        var randomPostal = postal[_random.Next(postal.Count)];

        return randomPostal;
    }
}
