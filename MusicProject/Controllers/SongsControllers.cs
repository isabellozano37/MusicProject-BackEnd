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
    public class SongsControllers : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISongsService _songsService;
        private readonly ServiceContext _serviceContext;
        public SongsControllers(IConfiguration configuration, ISongsService songsService, ServiceContext serviceContext)
        {
            _configuration = configuration;
            _songsService = songsService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertSongs")]
        public IActionResult Post([FromBody] Songs Songs)
        {
            try
            {
                return Ok(_songsService.InsertSongs(Songs));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el ID del rol: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetSongs")]
        public IActionResult GetSongs()
        {
            var Songs = _serviceContext.Songs.ToList();
            return Ok(Songs);

        }

        [HttpGet("GetSongsByCategory/{categoryId}")]
        public IActionResult GetSongsByCategory(int categoryId)
        
        {
            try
            {
                List<Songs> songs = _songsService.GetSongsByCategory(categoryId);

                if (songs == null || songs.Count == 0)
                {
                    return NotFound("No se encontraron canciones para la categoría especificada.");
                }

                return Ok(songs);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpDelete(Name = "DeleteSongs")]
        public IActionResult DeleteSongs(string SongName)
        {
            var Songs = _serviceContext.Songs.FirstOrDefault(p => p.SongName == SongName);
            if (Songs != null)
            {
                _serviceContext.Songs.Remove(Songs);
                _serviceContext.SaveChanges();
                return Ok("La cancion se ha eliminado correctamente.");
            }
            else
            {
                return NotFound("no se ha encontrado la cancion con el identificador especificado.");
            }
        }

        [HttpPut(Name = "UpdateSongs")]
        public IActionResult UpdateSongs(string SongName, [FromBody] Songs updatedSongs)
        {
            var Songs = _serviceContext.Songs.FirstOrDefault(p => p.SongName == SongName);
            if (Songs != null)
            {
                Songs.Imagen = updatedSongs.Imagen;
                Songs.SongName = updatedSongs.SongName;
                Songs.FilmName = updatedSongs.FilmName;
                Songs.Audio = updatedSongs.Audio;
                _serviceContext.SaveChanges();
                return Ok("La cancion se ha actualizado correctamente.");
            }
            else
            {
                return NotFound("No se ha encontrado la cancion con el identificador especificado.");
            }
        }
    }
}
