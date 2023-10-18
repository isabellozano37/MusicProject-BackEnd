using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MusicProject.IService;
using Microsoft.AspNetCore.Cors;
using MusicProject.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace MusicProject.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [EnableCors("AllowAll")]
    [Route("[controller]/[action]")]
    public class UsersControllers : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersService _userService;
        private readonly ServiceContext _serviceContext;
        public UsersControllers(IConfiguration configuration, IUsersService userService, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _userService = userService;
            _serviceContext = serviceContext;
        }
        [HttpPost(Name = "InsertUsers")]
        public IActionResult Post([FromBody] Users users)
        {
            try
            {
                // Verifica si la contraseña es lo suficientemente larga (por ejemplo, al menos 8 caracteres)
                if (users.Password.Length < 4)
                {
                    // Contraseña inválida, devolver un código de estado 400 (Bad Request)
                    return BadRequest("La contraseña debe tener al menos 4 caracteres.");
                }
                // Verifica si se proporcionó manualmente un valor para Id_rol en Swagger
                if (users.Id_Roll == 0)
                {
                    // Si no se proporcionó un valor manualmente, establece el valor predeterminado (2)
                    users.Id_Roll = 2;
                }
                return Ok(_userService.InsertUsers(users));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el ID del rol: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestModel loginRequest)
        {
            try
            {
                var user = _serviceContext.Users.FirstOrDefault(u => u.UserName == loginRequest.UserName);
                //if (user != null && BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
                if (user != null && loginRequest.Password == user.Password)
                {
                    var token = GenerateJwtToken(user);
                    return Ok(new { Token = token, Role = user.Id_Roll });
                    //return Ok(new { Token = token });
                    //return StatusCode(200, "Inicio de sesión exitoso");
                }
                else
                {
                    return StatusCode(401, "Credenciales incorrectas");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al iniciar sesión: {ex.Message}");
            }
        }
        private string GenerateJwtToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id_Users.ToString()),
                    new Claim(ClaimTypes.Role, user.Id_Roll.ToString())
                    // Otros claims si es necesario
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Duración del token
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpGet(Name = "GetUsers")]
        public IActionResult GetUsers()
        {
            var Users = _serviceContext.Users.ToList();
            return Ok(Users);
        }

        [HttpDelete(Name = "DeleteUser")]
        public IActionResult DeleteUser(string UserName)
        {
            var user = _serviceContext.Users.FirstOrDefault(p => p.UserName == UserName);
            if (user != null)
            {
                _serviceContext.Users.Remove(user);
                _serviceContext.SaveChanges();
                return Ok("El usuario se ha eliminado correctamente.");
            }
            else
            {
                return NotFound("No se ha encontrado el usuario con el identificador especificado.");
            }
        }

        [HttpPut(Name = "UpdateUser")]
        public IActionResult UpdateUser(string UserName, [FromBody] Users updatedUser)
        {
            var user = _serviceContext.Users.FirstOrDefault(p => p.UserName == UserName);
            if (user != null)
            {
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.UserName = updatedUser.UserName;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                _serviceContext.SaveChanges();
                return Ok("El ususario se ha actualizado correctamente.");
            }
            else
            {
                return NotFound("No se ha encontrado el usuario con el identificador especificado.");
            }
        }


    }
}








