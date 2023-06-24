using AutoMapper;
using Repository.Contracts;
using Service.Contracts.Contracts;
using Shared.Dtos;

namespace Service.Services;

public class CityService : ICityService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public CityService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<List<CityDto>> GetCitiesAsync(bool trackChanges)
    {
        var cities = await _repositoryManager.CityRepository.GetCitiesAsync(trackChanges);

        return _mapper.Map<List<CityDto>>(cities);
    }
}