using Repository.Context;
using Repository.Contracts;
using Repository.Repositories;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly AppDbContext _appDbContext;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<ICityRepository> _cityRepository;

    public RepositoryManager(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(appDbContext));
        _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(appDbContext));
    }

    public IUserRepository UserRepository => _userRepository.Value;
    public ICityRepository CityRepository => _cityRepository.Value;

    public async Task SaveAsync() => await _appDbContext.SaveChangesAsync();
}