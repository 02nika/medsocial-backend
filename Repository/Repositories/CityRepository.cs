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

    public async Task<List<City>> GetCitiesByCountryAsync(Guid countryId, bool trackChanges) =>
        await FindByCondition((city) => city.CountyId == countryId, trackChanges)
            .ToListAsync();
}