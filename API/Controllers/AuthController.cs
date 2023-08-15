using API.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationServices _auth;
        public AuthController(AuthenticationServices auth) {
            _auth = auth;
        }
  
        [AllowAnonymous]
        [HttpPost]public IActionResult Login([FromBody] Login user)
        {
            var token = _auth.GetUserToken(user.Email, user.Password);
            if(token.IsSusses) {
            return Ok(token);
            }
            return Unauthorized();
        }

    }
}
