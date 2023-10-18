using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using MusicProject.IService;

namespace MusicProject.Service
{
    public class DetailListService : BaseContextService, IDetailListService
    {
        public DetailListService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertDetailLists(DetailList DetailList)
        {
            _serviceContext.DetailList.Add(DetailList);
            _serviceContext.SaveChanges();
            return DetailList.Id_DetailList;
        }

    }
}