using Musify.Models;
using System.Collections.Generic;

namespace Musify.Interfaces
{
    public interface ISongRepository
    {
        void Create(Song song);
        void Delete(Song song);
        IEnumerable<Song> GetAll();
        IEnumerable<Song> GetAllWithAlbumAndArtist();
        Song GetById(int? id);
        Song GetByIdWithAlbum(int? id);
        Song GetByIdWithAlbumAndArtist(int? id);
    }
}