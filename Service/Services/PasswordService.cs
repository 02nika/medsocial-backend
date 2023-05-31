using System.Security.Cryptography;
using System.Text;
using Service.Contracts.Contracts;

namespace Service.Services;

public class PasswordService : IPasswordService
{
    public string ComputeSha256Hash(string rawData)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawData));

        var builder = new StringBuilder();
        foreach (var b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }
        return builder.ToString();
    }
}