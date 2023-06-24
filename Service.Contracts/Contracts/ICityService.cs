using Shared.Dtos;

namespace Service.Contracts.Contracts;

public interface ICityService
{
    Task<List<CityDto>> GetCitiesAsync(bool trackChanges);
}