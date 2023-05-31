using Entities.Models;
using Shared.Dtos;

namespace Service.Contracts.Contracts;

public interface IUserService
{
    Task<User> AddUserAsync(UserDto userDto);
    Task<UserDto> GetUserAsync(string email, string password, bool trackChanges);
}