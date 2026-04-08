using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClassLibrary.Contexts;
using ClassLibrary.Models;
using ClassLibrary.Options;
using Humanizer;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers;

public class LoginService(AppDbContext context)
{
    private AppDbContext _context = context;
    
    public async Task<string> AuthUserAsync(LoginOption loginOption)
    {
        try
        {
            string login = loginOption.Login;
            string password = loginOption.Password;

            if(String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.FirstOrDefault(u=> u.Login == login);

            if (user is null)
                return null;

            return VerifyPassword(password, user.Password) ? await GenerateToken(user) : null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    private bool VerifyPassword(string password, string passwordHash)
        => BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);

    private async Task<string> GenerateToken(User user)
    {
        string id = user.UserId;
        string login = user.Login;
        string role = "приветик";

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOption.SecretKey));
        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new(ClaimTypes.NameIdentifier, id),
            new(ClaimTypes.Name, login),
            new(ClaimTypes.Role, role),
        };

        var token = new JwtSecurityToken(
            signingCredentials: credentials,
            claims: claims,
            expires: DateTime.Now.AddMinutes(JwtOption.JwtActiveMinutes));
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
