namespace Repository.Contracts;

public interface IRepositoryManager
{
    public IUserRepository UserRepository { get; }
    public ICityRepository CityRepository { get; }
    public ICountryRepository CountryRepository { get; }
    public IGenderRepository GenderRepository { get; }
    Task SaveAsync();
}