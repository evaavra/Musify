using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Musify.ViewModels;

namespace Musify.Controllers
{
    public class AlbumsDetailsController : Controller
    {
        private ApplicationDbContext _context;

        public AlbumsDetailsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: AlbumsDetails
        public ActionResult Index()
        {
            var viewmodel = new AlbumsIndexViewModel()
            {
                Albums = _context.Albums.Include(a => a.Songs).ToList()
            };
            return View(viewmodel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = _context.Albums
                .Include(a => a.Songs)
                .SingleOrDefault(a => a.ID == id);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }
    }
}