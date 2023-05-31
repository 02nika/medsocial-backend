using Shared.Enums;

namespace Shared.Dtos;

public class UserDto
{
    public UserStatusDtoEnum Status { get; set; }
    public string Password { get; set; }
}