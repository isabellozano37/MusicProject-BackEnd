using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MusicProject.IService;
using Microsoft.AspNetCore.Cors;
using MusicProject.Service;

namespace MusicProject.Controllers
{
    [EnableCors("AllowAll")]
    [Route("[controller]/[action]")]
    public class DetailListControllers : ControllerBase
    {

        private readonly IDetailListService _detailListService;
        private readonly ServiceContext _serviceContext;

        public DetailListControllers(IDetailListService detailListService, ServiceContext serviceContext)
        {
            _detailListService = detailListService;
            _serviceContext = serviceContext;
        }


    }
}