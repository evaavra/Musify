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
using Musify.Interfaces;

namespace Musify.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SongsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SongsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ActionResult Index()
        {
            var songs = _unitOfWork.Songs.GetAllWithAlbumAndArtist().ToList();

            return View(songs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(_unitOfWork.Albums.GetAll(), "ID", "Title");
            //ViewBag.Heading = "Create";
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

                Album album = _unitOfWork.Albums.GetById(song.AlbumId);

                song.Thumbnail = album.Thumbnail;

                _unitOfWork.Songs.Create(song);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(_unitOfWork.Albums.GetAll(), "ID", "Title", song.AlbumId);
            return View(song);
        }


        public ActionResult Edit(int? id)
        {
            var song = _unitOfWork.Songs.GetByIdWithAlbum(id);

            if (song == null)
            {
                return HttpNotFound();
            }

            ViewBag.AlbumId = new SelectList(_unitOfWork.Albums.GetAll(), "ID", "Title");
            //ViewBag.Heading = "Edit";

            return View("Create", song);
        }

        
        
    }
}