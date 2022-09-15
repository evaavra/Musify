using Musify.Models;
using Musify.Repositories;
using Musify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ArtistRepository _artistRepository;
        private readonly AlbumRepository _albumRepository;

        public HomeController()
        {
            _context = new ApplicationDbContext();
            _artistRepository = new ArtistRepository();
            _albumRepository = new AlbumRepository();
        }

        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel()
            {
                Artists = _artistRepository.GetAll(),
                Albums = _albumRepository.GetAll()
            };

            return View(viewModel);
    }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat()
        {
            ViewBag.Message = "Your chat page";

            return View();
        }
    }
}