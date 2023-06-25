using Entities.Models;

namespace Repository.Contracts;

public interface IGenderRepository
{
    Task<List<Gender>> GetGendersAsync(bool trackChanges);
}