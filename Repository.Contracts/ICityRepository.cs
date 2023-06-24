using Entities.Models;

namespace Repository.Contracts;

public interface ICityRepository
{
    Task<List<City>> GetCitiesAsync(bool trackChanges);
}