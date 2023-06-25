using Shared.Dtos;

namespace Service.Contracts.Contracts;

public interface ILanguageService
{
    Task<List<LanguageDto>> GetLanguagesAsync(bool trackChanges);
}