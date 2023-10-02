using Data;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http.Cors;
using MusicProject.IService;
using System.Security.Authentication;
using Entities;
using MusicProject.Service;
using Microsoft.AspNetCore.Cors;
//using Microsoft.EntityFrameworkCore;

namespace MusicProject.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [EnableCors("AllowAll")]
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
        public IActionResult Post([FromBody] Users users)
        {
            try
            {
                // Verifica si la contraseña es lo suficientemente larga (por ejemplo, al menos 8 caracteres)
                if (users.Password.Length < 8)
                {
                    return BadRequest("La contraseña debe tener al menos 8 caracteres.");
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
