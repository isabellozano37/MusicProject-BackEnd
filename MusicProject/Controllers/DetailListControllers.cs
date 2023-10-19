//using Data;
//using Entities;
//using Microsoft.AspNetCore.Mvc;
//using MusicProject.IService;
//using Microsoft.AspNetCore.Cors;
//using MusicProject.Service;
//using System.Security.Authentication;

//namespace MusicProject.Controllers
//{
//    [EnableCors("AllowAll")]
//    [Route("[controller]/[action]")]
//    public class DetailListControllers : ControllerBase
//    {

//        private readonly IDetailListService _detailListService;
//        private readonly ServiceContext _serviceContext;

//        public DetailListControllers(IDetailListService detailListService, ServiceContext serviceContext)
//        {
//            _detailListService = detailListService;
//            _serviceContext = serviceContext;
//        }

//        [HttpPost(Name = "InsertDetailLists")]
//        public int Post([FromBody] DetailList DetailList)
//        {
//                return _detailListService.InsertDetailLists(DetailList);
//        }

//        [HttpGet(Name = "GetDetailLists")]
//        public IActionResult GetDetailLists()
//        {
//            var DetailLists = _serviceContext.DetailList.ToList();
//            return Ok(DetailLists);
//        }

//        [HttpPut(Name = "UpdateDetailLists")]
//        public IActionResult UpdateDetailLists(int Id_DetailList, [FromBody] DetailList updateDetailLists)
//        {
//            var user = _serviceContext.DetailList.FirstOrDefault(p => p.Id_DetailList == Id_DetailList);
//            if (user != null)
//            {
//                user.Id_DetailList = updateDetailLists.Id_DetailList;
//                user.Id_Songs = updateDetailLists.Id_Songs;

//                _serviceContext.SaveChanges();
//                return Ok("La lista se ha actualizado correctamente.");
//            }
//            else
//            {
//                return NotFound("No se ha encontrado la lista con el identificador especificado.");
//            }
//        }

//        [HttpDelete(Name = "DeleteDetailLists")]
//        public IActionResult DeleteDetailLists(int Id_DetailList)

//        {
//            var DetailLists = _serviceContext.DetailList.FirstOrDefault(p => p.Id_DetailList == Id_DetailList);
//            if (DetailLists != null)
//            {
//                _serviceContext.DetailList.Remove(DetailLists);
//                _serviceContext.SaveChanges();

//                return Ok("La lista se ha eliminado correctamente.");
//            }
//            else
//            {
//                return NotFound("No se ha encontrado la lista con el identificador especificado.");
//            }
//        }
//    }
//}
