namespace Service.Contracts.Contracts;

public interface IPasswordService
{
    string ComputeSha256Hash(string rawData);
}