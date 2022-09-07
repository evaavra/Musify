using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Musify.Areas.Admin.Controllers.api
{
    public class ArtistsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ArtistsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var artist = _context.Artists.Single(a => a.ID == id);
            if (artist == null)
                return NotFound();
            _context.Artists.Remove(artist);
            _context.SaveChanges();
            return Ok();
        }
    }
}
