using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using MusicProject.IService;

namespace MusicProject.Service
{
    public class UsersService : BaseContextService, IUsersService
    {
        public UsersService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertUsers(Users Users)
        {
            _serviceContext.Users.Add(Users);
            _serviceContext.SaveChanges();
            return Users.Id_Users;
        }

        public bool IsUserNameExists(string UserName)
        {
            // Realiza una consulta en tu base de datos para verificar si el nombre de usuario ya existe
            // Retorna true si existe, false si no existe
            return _serviceContext.Users.Any(u => u.UserName == UserName);
        }

    }
}
