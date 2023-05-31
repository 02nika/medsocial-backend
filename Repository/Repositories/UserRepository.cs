using Entities.Models;
using Repository.Context;
using Repository.Contracts;

namespace Repository.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}