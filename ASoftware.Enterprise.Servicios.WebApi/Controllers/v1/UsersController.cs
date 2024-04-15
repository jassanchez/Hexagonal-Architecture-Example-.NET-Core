using ASoftware.Enterprise.Aplicacion.DTO;
using ASoftware.Enterprise.Aplicacion.Interfaz;
using ASoftware.Enterprise.Servicios.WebApi.Helpers;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASoftware.Enterprise.Servicios.WebApi.Controllers.v1 {
    /// <summary>
    /// Controlador de Users para Autenticacion
    /// </summary>
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsersController : Controller
    {

        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Constructor del Controller
        /// </summary>
        /// <param name="usersApplication">Interfaz de capa de Aplicacion</param>
        /// <param name="appSettings">Archivo appsetings.json</param>
        public UsersController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings)
        {
            _usersApplication = usersApplication;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Metodo Authenthicate
        /// </summary>
        /// <param name="authDto">Objeto Json Esperado</param>
        /// <returns>Bearer Token para autorizacion</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UsersDTO authDto)
        {
            var response = _usersApplication.Authenticate(authDto.Username, authDto.Password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(authDto);
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }
            }

            return BadRequest(response);
        }

        private string BuildToken(UsersDTO userDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, userDto.UserId.ToString())
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
