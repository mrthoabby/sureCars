using API.Controllers;
using API.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Tests.Controllers.Auth
{
    public class LoginTest
    {
        private readonly AuthenticationServices _auth;
        private readonly AuthController _authController;

        public LoginTest()
        {
            var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {"Jwt:Key", "TEST_Aplication-TEStuNA BUENA KEY"},
                {"Jwt:Issuer", "https://localhost:7183/"},
                {"Jwt:Audience", "https://localhost:7183/"},
                {"Jwt:Subject", "test"}
            })
            .Build();
            _auth = new AuthenticationServices(configuration);
            _authController = new AuthController(_auth);
        }
        [Fact]
        public void Login_OK()
        {
            var user = new Login
            {
                Email = "admin@admin.co",
                Password = "1234"
            };
            var result = _authController.Login(user);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Login_Bad()
        {
            var user = new Login
            {
                Email = "admin@admin.cow",
                Password = "1234"
            };
            var result = _authController.Login(user);
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
