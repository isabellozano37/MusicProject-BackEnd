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
    public class ProductsControllers : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IProductsService _productsService;
        private readonly ServiceContext _serviceContext;
        public ProductsControllers(IConfiguration configuration, IProductsService productsService, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _productsService = productsService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertProducts")]
        public IActionResult Post([FromBody] Products Products)
        {
            return Ok(_productsService.InsertProducts(Products));
        }

        [HttpPut(Name = "UpdateProducts")]
        public IActionResult UpdateProducts(string SongName, [FromBody] Products updatedProducts)
        {
            var Products = _serviceContext.Products.FirstOrDefault(p => p.SongName == SongName);
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
        public IActionResult GetProducts([FromQuery] string SongName)
        {
            var seletedProducts = _serviceContext.Set<Products>().Where(u => u.SongName == SongName);
            if (seletedProducts != null)
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
        public IActionResult DeleteProducts(string SongName)
        {
            var Products = _serviceContext.Products.FirstOrDefault(p => p.SongName == SongName);
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











