using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Service.Contracts.Contracts;
using Service.Services;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ITokenService> _tokenService;

    public ServiceManager(IConfiguration configuration)
    {
        _tokenService =
            new Lazy<ITokenService>(() => new TokenService(configuration));
    }

    public ITokenService TokenService => _tokenService.Value;
}