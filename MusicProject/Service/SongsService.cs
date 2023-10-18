using Data;
using Entities;
using MusicProject.IService;

namespace MusicProject.Service
{
    public class SongsService : BaseContextService, ISongsService
    {
        public SongsService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertSongs(Songs Songs)
        {
            _serviceContext.Songs.Add(Songs);
            _serviceContext.SaveChanges();
            return Songs.Id_Songs;
        }
    }
}
