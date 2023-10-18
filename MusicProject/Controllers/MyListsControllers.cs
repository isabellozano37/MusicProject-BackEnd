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
    public class MyListsControllers : ControllerBase
    {

        private readonly IMylistsService _myListsService;
        private readonly ServiceContext _serviceContext;
        private object myLists;

        public MyListsControllers(IMylistsService myListsService, ServiceContext serviceContext)
        {
            _myListsService = myListsService;
            _serviceContext = serviceContext;
        }


        [HttpPost(Name = "InsertMyLists")]
        public IActionResult Post([FromBody] MyLists MyLists)
        {
            return Ok(_myListsService.InsertMyLists(MyLists));

        }

        [HttpDelete(Name = "DeleteMyLists")]
        public IActionResult DeleteMyLists(string Name_List)

        {
            var MyLists = _serviceContext.MyLists.FirstOrDefault(p => p.Name_List == Name_List);
            if (MyLists != null)
            {
                _serviceContext.MyLists.Remove(MyLists);
                _serviceContext.SaveChanges();

                return Ok("La lista se ha eliminado correctamente.");
            }
            else
            {
                return NotFound("No se ha encontrado la lista con el identificador especificado.");
            }
        }


        [HttpGet(Name = "GetMyLists")]
        public IActionResult GetMyLists()
        {
            var MyLists = _serviceContext.MyLists.ToList();
            return Ok(MyLists);
        }


        //[HttpPut(Name = "UpdateMyLists")]
        //public IActionResult UpdateMyLists(string Name_List, [FromBody] MyLists updatedMyLists)
        //{
        //    var user = _serviceContext.MyLists.FirstOrDefault(p => p.Name_List == Name_List);
        //    if (user != null)
        //    {
        //        MyLists.Name_List = updatedMyLists.Name_List;
                
        //        _serviceContext.SaveChanges();
        //        return Ok("La lista se ha actualizado correctamente.");
        //    }
        //    else
        //    {
        //        return NotFound("No se ha encontrado la lista con el identificador especificado.");
        //    }
        //}



    }

}
