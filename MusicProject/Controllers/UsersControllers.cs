using Data;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using MusicProject.IService;
using System.Security.Authentication;
using Entities;

namespace MusicProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class UsersControllers : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly ServiceContext _serviceContext;

        public UsersControllers(IUsersService userService, ServiceContext serviceContext)
        {
            _userService = userService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertUsers")]
        public int Post([FromBody] Users Users)
        {
          return _userService.InsertUsers(Users);  
        }

                // Verifica si la contraseña es lo suficientemente larga (por ejemplo, al menos 8 caracteres)
                if (Users.Password.Length < 8)
                {
                    // Contraseña inválida, devolver un código de estado 400 (Bad Request)
                    return BadRequest("La contraseña debe tener al menos 8 caracteres.");
                }

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

        [HttpGet(Name = "GetUsers")]
        public IActionResult GetUsers([FromQuery] string UserName, [FromQuery] string Password)
        {
            var seletedUser = _serviceContext.Set<Users>()
                               .Where(u => u.UserName == UserName
                                    && u.Password == Password
                                    && u.Id_Roll == 1)
                                .FirstOrDefault();

            if (seletedUser != null)
            {
                var Users = _serviceContext.Users.ToList();

                return Ok(Users);
            }
            else
            {
                return Unauthorized("El usuario no está autorizado o no existe");
            }
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

    }
}
