using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Musify.Interfaces;

namespace Musify.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApplicationDbContext _context;

        public AlbumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.Albums;
        }

        public IEnumerable<Album> GetAllWithArtistAndGenre()
        {
            return _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre);
        }

        public Album GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Albums
                .SingleOrDefault(a => a.ID == id);
        }

        public Album GetByIdWithArtist(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Albums
                .Include(a => a.Artist)
                .SingleOrDefault(a => a.ID == id);
        }

        public Album GetByIdWithArtistAndGenre(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var album = _context.Albums.Include(a => a.Artist).Include(a => a.Genre)
                .SingleOrDefault(a => a.ID == id);

            return album;
        }

        public void Create(Album album)
        {
            _context.Albums.Add(album);
        }

        public void Update(Album album)
        {
            _context.Entry(album).State = EntityState.Modified;
        }

        public void Delete(Album album)
        {
            _context.Albums.Remove(album);
        }

        public IEnumerable<Album> GetFirstFour()
        {
            var albums = _context.Albums;
            var firstFour = albums.Take(4);

            return firstFour;
        }
    }
}