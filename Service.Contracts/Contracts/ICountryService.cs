using Shared.Dtos;

namespace Service.Contracts.Contracts;

public interface ICountryService
{
    Task<List<CountryDto>> GetCountriesAsync(bool trackChanges);
}