using Shared.Enums;

namespace Shared.Dtos;

public class UserStatusDto
{
    public UserStatusDtoEnum Id { get; set; }
    public string? Name { get; set; }
}