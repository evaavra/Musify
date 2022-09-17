using Musify.Models;
using System.Collections.Generic;

namespace Musify.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAll();
    }
}