using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using MusicProject.IService;

namespace MusicProject.Service
{
    public class MyListsService : BaseContextService, IMyListsService
    {
        public MyListsService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertMyLists(MyLists MyLists)
        {
            _serviceContext.MyLists.Add(MyLists);
            _serviceContext.SaveChanges();
            return MyLists.Id_MyLists;
        }

    }
}
