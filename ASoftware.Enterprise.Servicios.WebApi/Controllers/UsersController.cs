using ASoftware.Enterprise.Aplicacion.DTO;
using ASoftware.Enterprise.Aplicacion.Interfaz;
using ASoftware.Enterprise.Servicios.WebApi.Helpers;
using ASoftware.Enterprise.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASoftware.Enterprise.Servicios.WebApi.Controllers {
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller {

        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;

        public UsersController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings) {
            _usersApplication = usersApplication;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]UsersDTO authDto) {
            var response = _usersApplication.Authenticate(authDto.Username, authDto.Password);
            if(response.IsSuccess) {
                if(response.Data !=null) {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                } else {
                    return NotFound(response);
                }
            }

            return BadRequest(response);
        }

        private string BuildToken(Response<UsersDTO> userDto) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, userDto.Data.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
