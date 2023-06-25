using Repository.Context;
using Repository.Contracts;
using Repository.Repositories;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly AppDbContext _appDbContext;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<ICityRepository> _cityRepository;
    private readonly Lazy<ICountryRepository> _countryRepository;
    private readonly Lazy<IGenderRepository> _genderRepository;
    private readonly Lazy<ILanguageRepository> _languageRepository;
    private readonly Lazy<ITimezoneRepository> _timezoneRepository;

    public RepositoryManager(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(appDbContext));
        _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(appDbContext));
        _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(appDbContext));
        _genderRepository = new Lazy<IGenderRepository>(() => new GenderRepository(appDbContext));
        _languageRepository = new Lazy<ILanguageRepository>(() => new LanguageRepository(appDbContext));
        _timezoneRepository = new Lazy<ITimezoneRepository>(() => new TimezoneRepository(appDbContext));
    }

    public IUserRepository UserRepository => _userRepository.Value;
    public ICityRepository CityRepository => _cityRepository.Value;
    public ICountryRepository CountryRepository => _countryRepository.Value;
    public IGenderRepository GenderRepository => _genderRepository.Value;
    public ILanguageRepository LanguageRepository => _languageRepository.Value;
    public ITimezoneRepository TimezoneRepository => _timezoneRepository.Value;
    
    public async Task SaveAsync() => await _appDbContext.SaveChangesAsync();
}