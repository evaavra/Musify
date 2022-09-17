using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Musify.Interfaces;

namespace Musify.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationDbContext _context;

        public SongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Song> GetAll()
        {
            return _context.Songs;
        }

        public IEnumerable<Song> GetAllWithAlbumAndArtist()
        {
            return _context
                .Songs
                .Include(s => s.Album.Artist);
        }

        public Song GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var song = _context.Songs
                .SingleOrDefault(s => s.ID == id);

            return song;
        }

        public Song GetByIdWithAlbum(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var song = _context.Songs
                .Include(s => s.Album)
                .SingleOrDefault(s => s.ID == id);

            return song;
        }

        public Song GetByIdWithAlbumAndArtist(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var song = _context
                .Songs
                .Include(s => s.Album.Artist)
                .SingleOrDefault(s => s.ID == id);

            return song;
        }

        public void Create(Song song)
        {
            _context.Songs.Add(song);
        }

        public void Delete(Song song)
        {
            _context.Songs.Remove(song);
        }
    }
}