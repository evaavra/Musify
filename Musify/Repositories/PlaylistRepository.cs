using Musify.Interfaces;
using Musify.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Musify.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly ApplicationDbContext _context;

        public PlaylistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Playlist> GetAll()
        {
            return _context.Playlists;
        }

        public IEnumerable<Playlist> GetAllWithPlDetailsAndSongs()
        {
            return _context.Playlists
                .Include(p => p.PlaylistDetails.Select(pl => pl.Song));
        }

        public IQueryable<Album> GetAllWithArtistAndGenre2()
        {
            return _context.Albums
                 .Include(a => a.Artist)
                 .Include(a => a.Genre);
        }

        public Playlist GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Playlists
                .SingleOrDefault(p => p.Id == id);
        }

        public Playlist GetByIdWithPlDetailsAndSongs(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context
                .Playlists
                .Include(p => p.PlaylistDetails.Select(pl => pl.Song))
                .SingleOrDefault(p => p.Id == id);
        }


        public void Create(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
        }

        public void Update(Playlist playlist)
        {
            _context.Entry(playlist).State = EntityState.Modified;
        }

        public void Delete(Playlist playlist)
        {
            _context.Playlists.Remove(playlist);
        }
    }
}