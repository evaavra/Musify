using Musify.Models;
using System.Collections.Generic;
using System.Linq;

namespace Musify.Interfaces
{
    public interface IPlaylistRepository
    {
        void Create(Playlist playlist);
        void Delete(Playlist playlist);
        IEnumerable<Playlist> GetAll();
        IQueryable<Album> GetAllWithArtistAndGenre2();
        IEnumerable<Playlist> GetAllWithPlDetailsAndSongs();
        Playlist GetById(int? id);
        Playlist GetByIdWithPlDetailsAndSongs(int? id);
        void Update(Playlist playlist);
    }
}