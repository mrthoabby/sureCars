using API.Services.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Configuration
{
    public class ConfigurationTest
    {

        [Fact]
        public void LoadConfigurationJWT_Success()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


            var Jwt = new Jwt();
            configuration.Bind("Jwt", Jwt);

            Assert.NotNull(Jwt.Key);
            Assert.NotNull(Jwt.Subject);
            Assert.NotNull(Jwt.Audience);
            Assert.NotNull(Jwt.Issuer);
        }
    }
}
