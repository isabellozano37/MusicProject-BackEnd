using Data;
using Microsoft.AspNetCore.Mvc;
using MusicProject.IService;
using System.Web.Http.Cors;

namespace MusicProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class ProductsControllers : ControllerBase
    {
        private readonly IUProcuctsService _ProductsService;
        private readonly ServiceContext _serviceContext;

        public ProductsControllers(IProductsService ProductsService, ServiceContext serviceContext)
        {
            _ProductsService = ProductsService;
            _serviceContext = serviceContext;
        }
     
    }
}
