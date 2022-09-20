using Musify.Models;
using System.Collections.Generic;
using System.Linq;

namespace Musify.Interfaces
{
    public interface IAlbumRepository
    {
        void Create(Album album);
        void Delete(Album album);
        IEnumerable<Album> GetAll();
        IEnumerable<Album> GetAllWithArtistAndGenre();
        IEnumerable<Album> GetAllWithSongs();
        IQueryable<Album> GetAllWithArtistAndGenre2();
        Album GetById(int? id);
        Album GetByIdWithSongs(int? id);
        Album GetByIdWithArtist(int? id);
        Album GetByIdWithArtistAndGenre(int? id);
        void Update(Album album);
    }
}