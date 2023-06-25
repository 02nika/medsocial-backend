using AutoMapper;
using Entities.Exceptions;
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

    public async Task<List<CityDto>> GetCitiesByCountryAsync(Guid countryId, bool trackChanges)
    {
        var cities = await _repositoryManager.CityRepository.GetCitiesByCountryAsync(countryId, trackChanges);

        if (cities.Count == 0) throw new CitiesNotFoundException();

        return _mapper.Map<List<CityDto>>(cities);
    }
}