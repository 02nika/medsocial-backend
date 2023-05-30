using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Medsocial.Solution.Models;
using Medsocial.Solution.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Medsocial.Solution.Controllers;

public class AuthController : ControllerBase
{
    private User _user = new User();

    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("register")]
    public ActionResult<User> Register(UserDto request)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        _user.Email = request.Email;
        _user.Password = passwordHash;

        return Ok(_user);
    }

    [HttpPost("login")]
    public ActionResult<User> Login(UserDto userDto)
    {
        _user.Email = userDto.Email;
        _user.Password = userDto.Password;

        var token = CreateToken(_user);

        return Ok(token);
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email),
            new(ClaimTypes.Role, "Admin"),
            new(ClaimTypes.Role, "Doctor"),
            new(ClaimTypes.Role, "User"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration["AppSettings:Key"]!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}