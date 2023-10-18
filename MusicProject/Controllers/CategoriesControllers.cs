using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MusicProject.IService;
using Microsoft.AspNetCore.Cors;


namespace MusicProject.Controllers
{
    [EnableCors("AllowAll")]
    [Route("[controller]/[action]")]
    public class CategoriesControllers : ControllerBase
    {

        private readonly ICategoriesService _categoriesService;
        private readonly ServiceContext _serviceContext;

        public CategoriesControllers(ICategoriesService categoriesService, ServiceContext serviceContext)
        {
            _categoriesService = categoriesService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertCategories")]
        public IActionResult Post([FromBody] Categories Categories)
        {
            return Ok(_categoriesService.InsertCategories(Categories));

        }

        [HttpGet(Name = "GetCategories")]
        public IActionResult GetCategories()
        {
            var Categories= _serviceContext.MyLists.ToList();
            return Ok(Categories);
        }

    }
}
