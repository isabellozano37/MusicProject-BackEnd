using Data;
using Entities;
using MusicProject.Controllers;
using MusicProject.IService;

namespace MusicProject.Service
{
    public class RollService : BaseContextService, IRollService
    {
        public RollService(ServiceContext serviceContext) : base(serviceContext)
        {
        }


        public int InsertRoll(Roll Roll)
        {
            _serviceContext.Roll.Add(Roll);
            _serviceContext.SaveChanges();
            return Roll.Id_Roll;
        }
    }
}
