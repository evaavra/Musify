using Musify.Interfaces;
using Musify.Models;
using Musify.Persistence;
using Musify.Repositories;
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
        private readonly IUnitOfWork _unitOfWork;

        public ArtistsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var artists = _unitOfWork.Artists.GetAll().ToList();
            return View(artists);
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
                    string fullPath = Path.Combine(Server.MapPath("~/img"), artist.Thumbnail);
                    artist.ImageFile.SaveAs(fullPath);
                }

                _unitOfWork.Artists.Create(artist);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            return View(artist);
        }

        public ActionResult Edit(int? id)
        {
            var artist = _unitOfWork.Artists.GetById(id);

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
                    string fullPath = Path.Combine(Server.MapPath("~/img"), artist.Thumbnail);
                    artist.ImageFile.SaveAs(fullPath);
                }

                _unitOfWork.Artists.Update(artist);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            return View(artist);
        }
    }
}