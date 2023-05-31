using AutoMapper;
using Entities.Models;
using Repository.Contracts;
using Service.Contracts.Contracts;
using Shared.Dtos;

namespace Service.Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task<User> AddUserAsync(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);

        await _repositoryManager.UserRepository.CreateUserAsync(user);

        await _repositoryManager.SaveAsync();

        return user;
    }
    
    public async Task<UserDto> GetUserAsync(string email, string password, bool trackChanges)
    {
        var user = await _repositoryManager.UserRepository.GetUserAsync(email, password, trackChanges);
        
        return _mapper.Map<UserDto>(user);
    }
}