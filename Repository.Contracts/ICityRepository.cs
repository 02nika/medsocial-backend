using Entities.Models;

namespace Repository.Contracts;

public interface ICityRepository
{
    Task<List<City>> GetCitiesByCountryAsync(Guid countryId, bool trackChanges);
}