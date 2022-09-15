using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Musify.Controllers
{
    public class ArtistsDetailsController : Controller
    {
        private ApplicationDbContext _context;

        public ArtistsDetailsController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: ArtistsDetails
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = _context.Artists
                .Include(a => a.Albums.Select(al => al.Songs))
                .SingleOrDefault(a => a.ID == id);

            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }
    }
}
