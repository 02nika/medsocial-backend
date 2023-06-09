using Service.Contracts.Contracts;

namespace Service.Contracts;

public interface IServiceManager
{
    public ITokenService TokenService { get; }
    IPasswordService PasswordService { get; }
    IUserService UserService { get; }
    ICityService CityService { get; }
    ICountryService CountryService { get; }
    IGenderService GenderService { get; }
    ILanguageService LanguageService { get; }
    ITimezoneService TimezoneService { get; }
}