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

        [HttpPost(Name = "InsertDetailList")]
        public IActionResult Post([FromBody] DetailList DetailList)
        {
            return Ok(_detailListService.InsertDetailList(DetailList));

        }
        [HttpGet(Name = "GetDetailList")]
        public IActionResult GetDetailList()
        {
            var DetailList = _serviceContext.DetailList.ToList();
            return Ok(DetailList);
        }


        //[HttpDelete(Name = "DeleteDetailList")]
        //public IActionResult DeleteDetailList(string MyLists)

        //{
        //    var DetailList = _serviceContext.MyLists.FirstOrDefault(p => p.MyLists == MyLists);
        //    if (DetailList != null)
        //    {
        //        _serviceContext.DetailList.Remove(DetailList);
        //        _serviceContext.SaveChanges();

        //        return Ok("La lista se ha eliminado correctamente.");
        //    }
        //    else
        //    {
        //        return NotFound("No se ha encontrado la lista con el identificador especificado.");
        //    }
        //}





    }
}