using Entities;

namespace MusicProject.IService
{
    public interface ISongsService
    {
        int InsertSongs(Songs Songs);
        List<Songs> GetSongsByCategory(int categoryId);
    }
}
