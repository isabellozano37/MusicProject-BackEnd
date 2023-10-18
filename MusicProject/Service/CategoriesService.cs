using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using MusicProject.IService;

namespace MusicProject.Service
{
    public class CategoriesService : BaseContextService, ICategoriesService
    {
        public CategoriesService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertCategories(Categories Categories)
        {
            _serviceContext.Categories.Add(Categories);
            _serviceContext.SaveChanges();
            return Categories.Id_Categories;
        }

    }

    internal interface ICategorioesService
    {
    }
}
