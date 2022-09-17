using Musify.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Musify.ViewModels;
using Musify.Repositories;
using Musify.Persistence;
using Musify.Interfaces;

namespace Musify.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AlbumsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlbumsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var albums = _unitOfWork.Albums.GetAllWithArtistAndGenre().ToList();
            return View(albums);
        }

        public ActionResult Create()
        {
            var viewmodel = new AlbumFormViewModel()
            {
                Heading = "Create an Album",
                Artists = _unitOfWork.Artists.GetAll().ToList(),
                Genres = _unitOfWork.Genres.GetAll().ToList()
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumFormViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.Heading = "Create an Album";
                viewmodel.Artists = _unitOfWork.Artists.GetAll().ToList();
                viewmodel.Genres = _unitOfWork.Genres.GetAll().ToList();
                return View(viewmodel);
            }
            if (viewmodel.ImageFile == null)
            {
                viewmodel.Thumbnail = "na_image.jpg";
            }
            else
            {
                viewmodel.Thumbnail = Path.GetFileName(viewmodel.ImageFile.FileName);
                string fullPath = Path.Combine(Server.MapPath("~/img"), viewmodel.Thumbnail);
                viewmodel.ImageFile.SaveAs(fullPath);
            }
            var album = new Album()
            {
                Title = viewmodel.Title,
                ReleaseDate = viewmodel.ReleaseDate,
                ArtistId = viewmodel.ArtistId,
                GenreId = viewmodel.GenreId,
                Thumbnail = viewmodel.Thumbnail
            };

            _unitOfWork.Albums.Create(album);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Albums");

        }

        public ActionResult Edit(int? id)
        {
            try
            {
                var album = _unitOfWork.Albums.GetByIdWithArtistAndGenre(id);

                if (album == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    var viewModel = new AlbumFormViewModel()
                    {
                        ID = album.ID,
                        Title = album.Title,
                        ReleaseDate = album.ReleaseDate,
                        Thumbnail = album.Thumbnail,
                        GenreId = album.GenreId,
                        ArtistId = album.ArtistId,
                        Artists = _unitOfWork.Artists.GetAll().ToList(),
                        Genres = _unitOfWork.Genres.GetAll().ToList(),
                        Heading = "Edit the album"
                    };
                    return View("Create", viewModel);
                }

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult Edit(AlbumFormViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.Heading = "Edit the Trainer";
                viewmodel.Artists = _unitOfWork.Artists.GetAll().ToList();
                viewmodel.Genres = _unitOfWork.Genres.GetAll().ToList();
                return View("Create", viewmodel);
            }
            if (viewmodel.ImageFile != null)
            {
                viewmodel.Thumbnail = Path.GetFileName(viewmodel.ImageFile.FileName);
                string fullPath = Path.Combine(Server.MapPath("~/img"), viewmodel.Thumbnail);
                viewmodel.ImageFile.SaveAs(fullPath);
            }

            var album = _unitOfWork.Albums.GetByIdWithArtistAndGenre(viewmodel.ID);

            album.Title = viewmodel.Title;
            album.ReleaseDate = viewmodel.ReleaseDate;
            album.ArtistId = viewmodel.ArtistId;
            album.GenreId = viewmodel.GenreId;
            album.Thumbnail = viewmodel.Thumbnail;

            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}