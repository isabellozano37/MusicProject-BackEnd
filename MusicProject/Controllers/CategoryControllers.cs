using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MusicProject.IService;
using Microsoft.AspNetCore.Cors;
using MusicProject.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MusicProject.Service;

namespace MusicProject.Controllers
{
    [EnableCors("AllowAll")]
    [Route("[controller]/[action]")]
    public class CategoryControllers : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICategoriesService _categriesService;
        private readonly ServiceContext _serviceContext;

        public CategoryControllers(IConfiguration configuration, ICategoriesService categriesService, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _categriesService = categriesService;
            _serviceContext = serviceContext;
        }

        [HttpGet(Name = "GetAllCategories")]
        public List<Categories> GetCategories()
        {
            return _categriesService.GetCategories();
        }
    }
}
