using AutoMapper;
using Repository.Contracts;
using Service.Contracts.Contracts;
using Shared.Dtos;

namespace Service.Services;

public class TimezoneService : ITimezoneService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public TimezoneService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<List<TimezoneDto>> GetTimezoneAsync(bool trackChanges)
    {
        var timezones = await _repositoryManager.TimezoneRepository.GetTimezonesAsync(trackChanges);

        return _mapper.Map<List<TimezoneDto>>(timezones);
    }
}
