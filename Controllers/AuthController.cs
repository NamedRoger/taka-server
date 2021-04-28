using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using server.Helpers.User;
using server.Models;
using server.Models.DTO;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly takaContext takaContext;
        private IUserManager<Usuario, int> userManager;
        private readonly IConfiguration configuration;

        public AuthController(takaContext takaContext, IUserManager<Usuario, int> userManager, IConfiguration configuration)
        {
            this.takaContext = takaContext;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResult>> Login([FromBody] Login login)
        {
            try
            {
                var findUsuario = await userManager.FindUser(login.Username);
                if (findUsuario == null)
                    return BadRequest("No existe el usuario");

                if (!BCrypt.Net.BCrypt.Verify(login.Password, findUsuario.Password))
                    return BadRequest("El password no es el correcto");

                var token = GenerateToken(findUsuario);
                return Ok(new AuthResult{ 
                    Token = token,
                    Result = true,
                    Errors = new List<string>()
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        private string GenerateToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,usuario.UserName),
                new Claim(ClaimTypes.Role,usuario.Role.Nombre),
                new Claim(ClaimTypes.PrimarySid,usuario.IdUsuario.ToString())
            };

            var claimIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Key"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimIdentity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}