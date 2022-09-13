using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Musify.ViewModels;
using Musify.Repositories;
using System.IO;

namespace Musify.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AlbumRepository _albumRepository;
        public SongsController()
        {
            _context = new ApplicationDbContext();
            _albumRepository = new AlbumRepository();
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

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(_albumRepository.GetAll(), "ID", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Song song)
        {
            if (ModelState.IsValid)
            {
                if (song.SongFile == null)
                {
                    song.SongPath = "NO SONG FILE";
                }
                else
                {
                    song.SongPath = Path.GetFileName(song.SongFile.FileName);
                    string fullPath = Path.Combine(Server.MapPath("~/Songs/"), song.SongPath);
                    song.SongFile.SaveAs(fullPath);
                }
                var album = _context.Albums.SingleOrDefault(a => a.ID == song.AlbumId);
                song.Thumbnail = album.Thumbnail;
                _context.Songs.Add(song);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(_albumRepository.GetAll(), "ID", "Title", song.AlbumId);
            return View(song);
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