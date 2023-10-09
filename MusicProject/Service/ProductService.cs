using Data;
using Entities;
using MusicProject.Controllers;
using MusicProject.IService;

namespace MusicProject.Service
{
    public class ProductsService : BaseContextService, IProductsServices
    {
        public ProductsService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        
        public int InsertProducts(Products Products)
        {
            _serviceContext.Products.Add(Products);
            _serviceContext.SaveChanges();
            return Products.Id_Products;
        }
    }
}
