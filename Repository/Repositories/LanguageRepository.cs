using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;

namespace Repository.Repositories;

public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
{
    public LanguageRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<List<Language>> GetLanguagesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .ToListAsync();
}
