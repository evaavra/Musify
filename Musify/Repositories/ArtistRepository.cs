using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Musify.Interfaces;

namespace Musify.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDbContext _context;

        public ArtistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists;
        }

        public IEnumerable<Artist> GetAllWithAlbums()
        {
            return _context.Artists
                .Include(a => a.Albums);
        }

        public IQueryable<Artist> GetAllWithAlbums2()
        {
            return _context.Artists
                .Include(a => a.Albums);
        }

        public Artist GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Artists
                .SingleOrDefault(a => a.ID == id);
        }

        public Artist GetByIdWithAlbums(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Artists
                .Include(a => a.Albums)
                .SingleOrDefault(a => a.ID == id);
        }

        public Artist GetByIdWithAlbumsAndSongs(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Artists
                .Include(a => a.Albums.Select(al => al.Songs))
                .SingleOrDefault(a => a.ID == id);
        }

        public void Create(Artist artist)
        {
            _context.Artists.Add(artist);
        }

        public void Update(Artist artist)
        {
            _context.Entry(artist).State = EntityState.Modified;
        }

        public void Delete(Artist artist)
        {
            _context.Artists.Remove(artist);
        }
        
    }
}