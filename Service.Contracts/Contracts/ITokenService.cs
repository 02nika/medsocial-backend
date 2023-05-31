using Shared.Enums;

namespace Service.Contracts.Contracts;

public interface ITokenService
{
    string CreateToken(string userEmail, UserStatusDtoEnum userStatus);
}