using Shared.Dtos;

namespace Service.Contracts.Contracts;

public interface ITimezoneService
{
    Task<List<TimezoneDto>> GetTimezoneAsync(bool trackChanges);
}