using Musify.Models;
using System.Collections.Generic;

namespace Musify.Interfaces
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAll();
        void Create(Artist artist);
        void Delete(Artist artist);
        IEnumerable<Artist> GetAllWithAlbums();
        Artist GetById(int? id);
        Artist GetByIdWithAlbums(int? id);
        Artist GetByIdWithAlbumsAndSongs(int? id);
        void Update(Artist artist);
    }
}