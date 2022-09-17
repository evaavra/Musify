using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Musify.Interfaces;

namespace Musify.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres;
        }
    }
}