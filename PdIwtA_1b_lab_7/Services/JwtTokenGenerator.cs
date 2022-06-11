using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace test_7.Services
{
    public interface IJwtTokenGenerator
    {
        string Generate(string user, string role);
    }
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        //public class User
        //{
        //    public string Name { get; set; }
        //    public string Password { get; set; }
        //}

        //public static List<User> users = new List<User>()
        //{
        //    new User() { Name = "Marcin", Password = "12345"},
        //    new User() { Name = "Gienek", Password = "111"},
        //    new User() { Name = "Mirek", Password = "222"},
        //};

        public string Generate(string user, string role)
        {
            var keyBytes = Encoding.UTF8.GetBytes("w+1alOGke7bSPTgeMVlDXS5FRg3jcjRxkBtG0u3NrOo=");
            var secret = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.Role, role)
            };
            var token = new JwtSecurityToken(
                "test",
                claims: claims,
                expires: DateTime.Now.AddMinutes(0.5f),
                signingCredentials: credentials
            );
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
