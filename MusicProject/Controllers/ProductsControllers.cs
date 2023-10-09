using Data;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using MusicProject.IService;
using System.Security.Authentication;
using Entities;
using MusicProject.Service;

namespace MusicProject.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class ProductsControllers : ControllerBase
    {
        private readonly ProductsService _ProductsService;
        private readonly ServiceContext _serviceContext;

        public ProductsControllers(IProductsService ProductsService, ServiceContext serviceContext)
        {
            _ProductsService =(ProductsService?)ProductsService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertProducts")]
        public int Post([FromBody] Products Products)
        {
            return _ProductsService.InsertProducts(Products);

        }

        [HttpPut(Name = "UpdateProducts")]
        public IActionResult UpdateProducts(string ProductsName, [FromBody] Products updatedProducts)
        {
            var Products = _serviceContext.Products.FirstOrDefault(p => p.ProductsName == ProductsName);

            if (Products != null)
            {
                Products.Imagen = updatedProducts.Imagen;
                Products.SongName = updatedProducts.SongName;
                Products.FilmName = updatedProducts.FilmName;
                Products.Audio = updatedProducts.Audio;
                

                _serviceContext.SaveChanges();

                return Ok("El Producto se ha actualizado correctamente.");
            }
            else
            {
                return NotFound("No se ha encontrado el Producto con el identificador especificado.");
            }
        }

        [HttpGet(Name = "GetProducts")]
        public IActionResult GetProducts([FromQuery] string ProductsName)
        {
            var seletedProducts = _serviceContext.Set<Products>().Where(u => u.ProductsName == ProductsName);
                                    
                                   

            if 
                (seletedProducts!= null)
            {
                var Products = _serviceContext.Products.ToList();

                return Ok(Products);
            }
            else
            {
                return Unauthorized("El Producto no está autorizado o no existe");
            }
        }

        [HttpDelete(Name = "DeleteProducts")]

            public IActionResult DeleteProducts(string ProductsName)
        {
            var Products = _serviceContext.Products.FirstOrDefault(p => p.ProductsName == ProductsName);

            if (Products != null)
            {
                _serviceContext.Products.Remove(Products);
                _serviceContext.SaveChanges();

                return Ok("El Producto se ha eliminado correctamente.");
            }
            else
            {
                return NotFound("no se ha encontrado el producto con el identificador especificado.");
            }
        }

    }
    
    
}
