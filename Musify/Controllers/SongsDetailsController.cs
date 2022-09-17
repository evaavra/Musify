using Musify.Interfaces;
using Musify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musify.Controllers
{
    public class SongsDetailsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SongsDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: SongsDetails
        public ActionResult Index(string query = null)
        {
            var songs = _unitOfWork.Songs.GetAllWithAlbumAndArtist();

            if (!String.IsNullOrEmpty(query))
            {
                songs = songs
                    .Where(s =>
                        s.Title.Contains(query) ||
                        s.Album.Artist.Name.Contains(query));
            }

            var viewmodel = new SongsDetailsViewModel()
            {
                Songs = songs.ToList(),
                SearchTerm = query
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Search(SongsDetailsViewModel viewmodel)
        {
            return RedirectToAction("Index", "SongsDetails", new { query = viewmodel.SearchTerm });
        }
    }
}