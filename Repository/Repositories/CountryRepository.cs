using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;

namespace Repository.Repositories;

public class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    
    public async Task<List<Country>> GetCountriesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .ToListAsync();
}