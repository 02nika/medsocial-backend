using Entities.Models;

namespace Repository.Contracts;

public interface ITimezoneRepository
{
    Task<List<Timezone>> GetTimezonesAsync(bool trackChanges);
}