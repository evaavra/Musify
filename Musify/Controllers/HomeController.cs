using Microsoft.AspNet.Identity;
using Musify.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel()
            {
                Artists = _unitOfWork.Artists.GetAll(),
                Albums = _unitOfWork.Albums.GetAll()
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
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.Users.GetUser( userId);
            if (user.HasPaid == false)
            {
                return RedirectToAction("Index", "Payment");
            }
            return View();
        }

        public ActionResult PartialPremium()
        {
            var id = User.Identity.GetUserId();
            var user = _unitOfWork.Users.GetUser(id);
            return PartialView(user);
        }
    }
}