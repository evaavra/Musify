using Musify.Models;
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
        private readonly ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var users = _context.Users.ToList();
            var usersHavePaid = users.Where(u => u.HasPaid == true).ToList();
            var usersHaveNotPaid = users.Where(u => u.HasPaid == false).ToList();

            var viewModel = new AllDataViewModel()
            {
                Artists = _context.Artists.ToList(),
                Albums = _context.Albums.ToList(),
                Songs = _context.Songs.ToList(),
                Users = users,
                UsersHavePaid = usersHavePaid,
                UsersHaveNotPaid = usersHaveNotPaid
            };
            return View(viewModel);
        }
    }
}