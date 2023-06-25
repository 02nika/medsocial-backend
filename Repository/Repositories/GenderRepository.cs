using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;

namespace Repository.Repositories;

public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
{
    public GenderRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    
    public async Task<List<Gender>> GetGendersAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .ToListAsync();
}