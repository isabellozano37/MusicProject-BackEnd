using Data;
using Entities;
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
    }
}
