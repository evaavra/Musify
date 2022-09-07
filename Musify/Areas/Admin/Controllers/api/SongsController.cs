using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Musify.Areas.Admin.Controllers.api
{
    public class SongsDeleteController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public SongsDeleteController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var song = _context.Songs.Single(s => s.ID == id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            _context.SaveChanges();
            return Ok();
        }
    }
}
