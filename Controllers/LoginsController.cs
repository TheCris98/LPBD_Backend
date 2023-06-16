using LPBD_Backend.Clases;
using LPBD_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LPBD_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly LPBD_BDContext _BDContext;
        private readonly AppSettings _appSettings; 

        public LoginsController (LPBD_BDContext context, IOptions<AppSettings> appSettings1)
        {
            _BDContext = context;
            _appSettings = appSettings1.Value;
        }

        [HttpPost]
        public async Task<IActionResult> GetUsuarioAutenticado(Login credenciales)
        {
            Autenticar autenticar = new Autenticar();
            var usuario = await _BDContext.Personals.Where(user => user.UserPer == credenciales.Usuario).FirstOrDefaultAsync<Personal>();
            if (usuario == null)
            {
                return BadRequest(new { message = " Usuario no encontrado" });
            }
            else
            {
                var contrasenha = Encriptar.GetSHA256(credenciales.Contrasena);
                if (usuario.PassPer.Equals(contrasenha))
                {
                    autenticar.usuario = usuario;
                    autenticar.token = GetToken(usuario.IdPer);
                    return Ok(autenticar);
                }
                return BadRequest(new { message = " Contraseña incorrecta" });
            }
        }

        private string GetToken(int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Llave);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, id.ToString())
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
