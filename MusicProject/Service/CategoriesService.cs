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
        public List<Categories> GetCategories()
        {
            return _serviceContext.Categories.ToList();
        }
    }
}
