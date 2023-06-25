using Shared.Dtos;

namespace Service.Contracts.Contracts;

public interface IGenderService
{
    Task<List<GenderDto>> GetGendersAsync(bool trackChanges);
}