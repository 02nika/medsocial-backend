namespace Service.Contracts.Contracts;

public interface ITokenService
{
    string CreateToken(string userEmail, string userStatusName);
}