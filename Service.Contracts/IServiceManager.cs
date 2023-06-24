using Service.Contracts.Contracts;

namespace Service.Contracts;

public interface IServiceManager
{
    public ITokenService TokenService { get; }
    IPasswordService PasswordService { get; }
    IUserService UserService { get; }
    ICityService CityService { get; }
}