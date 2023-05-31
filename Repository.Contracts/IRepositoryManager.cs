namespace Repository.Contracts;

public interface IRepositoryManager
{
    public IUserRepository UserRepository { get; }
    Task SaveAsync();
}