using AutoMapper;
using Repository.Contracts;
using Service.Contracts.Contracts;
using Shared.Dtos;

namespace Service.Services;

public class LanguageService : ILanguageService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public LanguageService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<List<LanguageDto>> GetLanguagesAsync(bool trackChanges)
    {
        var languages = await _repositoryManager.LanguageRepository.GetLanguagesAsync(trackChanges);

        return _mapper.Map<List<LanguageDto>>(languages);
    }
}

