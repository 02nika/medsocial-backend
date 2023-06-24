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

    public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration, IMapper mapper)
    {
        _tokenService =
            new Lazy<ITokenService>(() => new TokenService(configuration));
        _passwordService = new Lazy<IPasswordService>(() => new PasswordService());
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
        _cityService = new Lazy<ICityService>(() => new CityService(repositoryManager, mapper));
    }

    public ITokenService TokenService => _tokenService.Value;
    public IPasswordService PasswordService => _passwordService.Value;
    public ICityService CityService => _cityService.Value;
    public IUserService UserService => _userService.Value;
}