using Entities.Models;

namespace Repository.Contracts;

public interface ICountryRepository
{
    Task<List<Country>> GetCountriesAsync(bool trackChanges);
}