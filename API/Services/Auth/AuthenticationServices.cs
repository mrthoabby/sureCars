using Application.Wrappers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services.Auth
{
    public class AuthenticationServices
    {
        private readonly List<User> _user;
        private readonly IConfiguration _configuration;
        public AuthenticationServices(IConfiguration configuration)
        {
            _user = new List<User>() {
            new User
            {
                Email="admin@admin.co",
                Password="1234",
                UserName="Admin"

            }
            };
            _configuration = configuration;
        }
        public ResponseResult<string> GetUserToken(string email, string password)
        {
            var user = _user.FirstOrDefault(user => user.Email.ToLower() == email.ToLower() && user.Password == password);
            if (user is not null)
            {

                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("name",user.UserName),
                new Claim("email",user.Email),
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: singIn
                    );
                return new ResponseResult<string>(true, "token", new JwtSecurityTokenHandler().WriteToken(token), null);
            }
            return new ResponseResult<string>(false, "token", "null", null);
        }

    }
}

