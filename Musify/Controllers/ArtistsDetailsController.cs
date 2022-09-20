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
    public class ArtistsDetailsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistsDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: ArtistsDetails
        public ActionResult Index()
        {
            var viewmodel = new ArtistsIndexViewModel()
            {
                Artists = _unitOfWork.Artists.GetAllWithAlbums().ToList()
            };
            return View(viewmodel);
        }

        public ActionResult Details(int? id)
        {
            Artist artist = _unitOfWork.Artists.GetByIdWithAlbumsAndSongs(id);

            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }
    }
}
