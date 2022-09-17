using Musify.Interfaces;
using Musify.Models;
using Musify.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musify.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IArtistRepository Artists { get; private set; }
        public IAlbumRepository Albums { get; private set; }
        public ISongRepository Songs { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IUserRepository Users { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Artists = new ArtistRepository(_context);
            Albums = new AlbumRepository(_context);
            Songs = new SongRepository(_context);
            Genres = new GenreRepository(_context);
            Users = new UserRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}