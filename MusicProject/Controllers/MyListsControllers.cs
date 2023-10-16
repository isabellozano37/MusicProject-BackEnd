using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
//using MusicProject.Controles;
using System.Security.Authentication;
using System.Web.Http.Cors;
using MusicProject.IService;


namespace MusicProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class MyListsControllers : ControllerBase
    {
        private readonly IMyListsService _myListsService;
        private readonly ServiceContext _serviceContext;

        public MyListsControllers(IMyListsService myListsService, ServiceContext serviceContext)
        {
            _myListsService = myListsService;
            _serviceContext = serviceContext;
        }


        [HttpPost(Name = "Insert")]
        public int Post([FromQuery] string FirstName_Users, [FromQuery] string password, [FromBody] MyLists MyLists)
        {
            var selectedUser = _serviceContext.Set<Users>()
                               .Where(u => u.FirstName == FirstName_Users
                                    && u.Password == password
                                    && u.Id_Roll == 2)
                                .FirstOrDefault();

            if (selectedUser != null)
            {

                return _myListsService.InsertMyLists(MyLists);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }
    }
    ////[HttpGet(Name = "GetMyLists")]
    ////public IActionResult GetMyLists([FromQuery] string Name_lists)
    ////{
    ////    var seletedMyLists = _serviceContext.Set<MyLists>().Where(u => u.Name_List == Name_List);
    ////    if (seletedMyLists!= null)
    ////    {
    ////        var MyLists = _serviceContext.MyLists.ToList();
    ////        return Ok(MyLists);
    ////    }
    ////    else
    ////    {
    ////        return Unauthorized("El Producto no está autorizado o no existe");
    ////    }
    ////}


    //            [HttpPut(Name = "UpdateMyLists")]
    //            public IActionResult UppdateMyLists(string MyLists, [FromBody] MyLists updatedMyLists)
    //            {
    //                var myLists = _serviceContext.MyLists.FirstOrDefault(p => p.Name_List == Name_List);
    //                if (MyLists != null)
}
//                {
//                    MyLists.Name_list = UpdateMyLists.Name_Lists;

//                    _serviceContext.SaveChanges();
//                    return Ok("El Producto se ha actualizado correctamente.");
//                }
//                else
//                {
//                    return NotFound("No se ha encontrado el Producto con el identificador especificado.");
//                }
//            }
//        }
//    }
//}
