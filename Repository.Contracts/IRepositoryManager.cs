namespace Repository.Contracts;

public interface IRepositoryManager
{
    public IUserRepository UserRepository { get; }
    public ICityRepository CityRepository { get; }
    Task SaveAsync();
}