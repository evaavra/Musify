using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Musify.ViewModels;
using Musify.Interfaces;

namespace Musify.Controllers
{
    public class AlbumsDetailsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlbumsDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: AlbumsDetails
        public ActionResult Index()
        {
            var viewmodel = new AlbumsIndexViewModel()
            {
                Albums = _unitOfWork.Albums.GetAllWithSongs().ToList()
            };
            return View(viewmodel);
        }

        public ActionResult Details(int? id)
        {
            Album album = _unitOfWork.Albums.GetByIdWithSongs(id);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }
    }
}