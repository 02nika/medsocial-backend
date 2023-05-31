using Service.Contracts.Contracts;

namespace Service.Contracts;

public interface IServiceManager
{
    public ITokenService TokenService { get; }
}