using AutoMapper;
using Entities.Exceptions;
using Repository.Contracts;
using Service.Contracts.Contracts;
using Shared.Dtos;

namespace Service.Services;

public class CountryService : ICountryService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public CountryService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<List<CountryDto>> GetCountriesAsync(bool trackChanges)
    {
        var countries = await _repositoryManager.CountryRepository.GetCountriesAsync(trackChanges);

        return _mapper.Map<List<CountryDto>>(countries);
    }
}