using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Musify.ViewModels;

namespace Musify.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SongsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Admin/Songs
        public ActionResult Index()
        {
            var songs = _context
                .Songs
                .Include(s => s.Album.Artist)
                .ToList();
            return View(songs);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var song = _context
                .Songs
                .Include(s => s.Album.Artist)
                .SingleOrDefault(s => s.ID == id);

            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }



        public ActionResult New()
        {
            var albums = _context.Albums.ToList();
            var viewmodel = new SongFormViewModel()
            {
                Song = new Song(),
                Albums = albums
            };

            return View("SongForm", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Song song)
        {
            song.Youtube = $"https://www.youtube.com/embed/{song.Youtube};";

            if (song.ID == 0)
            {
                var album = _context.Albums.SingleOrDefault(a => a.ID == song.AlbumId);
                song.Thumbnail = album.Thumbnail;
                _context.Songs.Add(song);
            }
            else
            {
                var songInDb = _context.Songs.Include(s => s.Album).SingleOrDefault(s => s.ID == song.ID);
                songInDb.Thumbnail = songInDb.Album.Thumbnail;
                songInDb.Title = song.Title;
                songInDb.Youtube = song.Youtube;
                songInDb.AlbumId = song.AlbumId;
            }

            if (!ModelState.IsValid)
            {
                var viewModel = new SongFormViewModel()
                {
                    Song = song,
                    Albums = _context.Albums.ToList()
                };

                return View("SongForm", viewModel);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Songs");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var song = _context.Songs
                .Include(s => s.Album)
                .SingleOrDefault(s => s.ID == id);

            if (song == null)
            {
                return HttpNotFound();
            }

            var albums = _context.Albums.ToList();

            var viewModel = new SongFormViewModel()
            {
                Song = song,
                Albums = albums
            };

            return View("SongForm", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}