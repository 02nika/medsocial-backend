using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;

namespace Repository.Repositories;

public class TimezoneRepository : RepositoryBase<Timezone>, ITimezoneRepository
{
    public TimezoneRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    
    public async Task<List<Timezone>> GetTimezonesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .ToListAsync();
}
