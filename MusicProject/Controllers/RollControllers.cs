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
    public class RollControllers : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRollService _rollService;
        private readonly ServiceContext _serviceContext;
        public RollControllers(IConfiguration configuration, IRollService rollService, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _rollService = rollService;
            _serviceContext = serviceContext;
        }
        [HttpPost(Name = "InsertRoll")]
        public IActionResult Post([FromBody] Roll Roll)
        {
            return Ok(_rollService.InsertRoll(Roll));
        }

    }
}