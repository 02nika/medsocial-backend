using Shared.Enums;
using Shared.Models;

namespace Service.Contracts.Contracts;

public interface ITokenService
{
    string CreateToken(User user, UserStatus userStatus);
}