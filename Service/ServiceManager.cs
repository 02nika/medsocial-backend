using AutoMapper;
using Microsoft.Extensions.Configuration;

using Repository.Contracts;

using Service.Contracts;
using Service.Contracts.Contracts;
using Service.Services;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ITokenService> _tokenService;
    private readonly Lazy<IPasswordService> _passwordService;
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<ICityService> _cityService;
    private readonly Lazy<ICountryService> _countryService;
    private readonly Lazy<IGenderService> _genderService;
    private readonly Lazy<ILanguageService> _languageService;
    private readonly Lazy<ITimezoneService> _timezoneService;

    public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration, IMapper mapper)
    {
        _tokenService =
            new Lazy<ITokenService>(() => new TokenService(configuration));
        _passwordService = new Lazy<IPasswordService>(() => new PasswordService());
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
        _cityService = new Lazy<ICityService>(() => new CityService(repositoryManager, mapper));
        _countryService = new Lazy<ICountryService>(() => new CountryService(repositoryManager, mapper));
        _genderService = new Lazy<IGenderService>(() => new GenderService(repositoryManager, mapper));
        _languageService = new Lazy<ILanguageService>(() => new LanguageService(repositoryManager, mapper));
        _timezoneService = new Lazy<ITimezoneService>(() => new TimezoneService(repositoryManager, mapper));
    }

    public ITokenService TokenService => _tokenService.Value;
    public IPasswordService PasswordService => _passwordService.Value;
    public ICityService CityService => _cityService.Value;
    public IUserService UserService => _userService.Value;
    public ICountryService CountryService => _countryService.Value;
    public IGenderService GenderService => _genderService.Value;
    public ILanguageService LanguageService => _languageService.Value;
    public ITimezoneService TimezoneService => _timezoneService.Value;
}