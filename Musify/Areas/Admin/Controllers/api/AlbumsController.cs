using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Musify.Areas.Admin.Controllers.api
{
    //[RoutePrefix("api/Albums")]
    public class AlbumsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AlbumsController()
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
            var album = _context.Albums.Single(a => a.ID == id);
            if (album == null)
                return NotFound();
            _context.Albums.Remove(album);
            _context.SaveChanges();
            return Ok();
        }
    }
}
