using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;

namespace Repository.Repositories;

public class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<List<City>> GetCitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges).ToListAsync();

}