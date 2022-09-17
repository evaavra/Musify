using Musify.Interfaces;
using Musify.Models;
using Musify.Repositories;
using Musify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Musify.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var users = _unitOfWork.Users.GetAll().ToList();
            var usersHavePaid = _unitOfWork.Users.GetPremiumUsers().ToList();
            var usersHaveNotPaid = _unitOfWork.Users.GetNotPremiumUsers().ToList();

            var viewModel = new AllDataViewModel()
            {
                Artists = _unitOfWork.Artists.GetAll().ToList(),
                Albums = _unitOfWork.Albums.GetAll().ToList(),
                Songs = _unitOfWork.Songs.GetAll().ToList(),
                Users = users,
                UsersHavePaid = usersHavePaid,
                UsersHaveNotPaid = usersHaveNotPaid
            };
            return View(viewModel);
        }
    }
}