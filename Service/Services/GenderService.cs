using AutoMapper;
using Repository.Contracts;
using Service.Contracts.Contracts;
using Shared.Dtos;

namespace Service.Services;

public class GenderService : IGenderService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GenderService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<List<GenderDto>> GetGendersAsync(bool trackChanges)
    {
        var genders = await _repositoryManager.GenderRepository.GetGendersAsync(trackChanges);

        return _mapper.Map<List<GenderDto>>(genders);
    }
}