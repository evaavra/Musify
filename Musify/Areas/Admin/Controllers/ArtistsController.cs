using Musify.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Musify.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArtistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtistsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var artists = _context.Artists.ToList();
            return View(artists);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Artist artist = _context.Artists.SingleOrDefault(a => a.ID == id);

            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                if (artist.ImageFile == null)
                {
                    artist.Thumbnail = "na_image.jpg";
                }
                else
                {
                    artist.Thumbnail = Path.GetFileName(artist.ImageFile.FileName);
                    string fullPath = Path.Combine(Server.MapPath("~/img/artistsImages"), artist.Thumbnail);
                    artist.ImageFile.SaveAs(fullPath);
                }
                _context.Artists.Add(artist);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = _context.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid)
            {
                if (artist.ImageFile == null)
                {
                    artist.Thumbnail = "na_image.jpg";
                }
                else
                {
                    artist.Thumbnail = Path.GetFileName(artist.ImageFile.FileName);
                    string fullPath = Path.Combine(Server.MapPath("~/img/artistsImages"), artist.Thumbnail);
                    artist.ImageFile.SaveAs(fullPath);
                }

                _context.Entry(artist).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = _context.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = _context.Artists.Find(id);
            _context.Artists.Remove(artist);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}