using Language = Entities.Models.Language;

namespace Repository.Contracts;

public interface ILanguageRepository
{
    Task<List<Language>> GetLanguagesAsync(bool trackChanges);
}