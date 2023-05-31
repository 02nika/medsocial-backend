using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;

namespace Repository.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    
    public async Task CreateUserAsync(User user)
    {
        await CreateAsync(user);
    }

    public async Task<User?> GetUserAsync(string email, string password, bool trackChanges) => 
        await FindByCondition(user => user.Email == email && user.Password == password, trackChanges)
            .FirstOrDefaultAsync();
}