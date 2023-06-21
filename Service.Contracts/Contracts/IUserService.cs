using Shared.Dtos;

namespace Service.Contracts.Contracts;

public interface IUserService
{
    Task<Guid> CreateUserAsync(UserDto userDto);
    Task<UserDto> GetUserAsync(string email, string password, bool trackChanges);
    Task<bool> UserExistAsync(string email);
}