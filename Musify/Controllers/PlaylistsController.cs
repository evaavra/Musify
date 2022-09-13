using Microsoft.AspNet.Identity;
using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Musify.ViewModels;

namespace Musify.Controllers
{
    public class PlaylistsController : Controller
    {
        private ApplicationDbContext _context;

        public PlaylistsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Playlists
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var playlists = _context.Playlists.Include(p => p.PlaylistDetails.Select(pl => pl.Song));
            var userPlaylists = new List<Playlist>();
            foreach (var pl in playlists)
            {
                if (pl.UserId == userId)
                {
                    userPlaylists.Add(pl);
                }
            }
            ViewBag.User = _context.Users.SingleOrDefault(u => u.Id == userId);
            return View(userPlaylists);
        }

        public ActionResult Create()
        {
            var songs = _context.Songs.ToList();
            var viewModel = new PlaylistNewViewModel()
            {
                Songs = songs
            };
            return View(viewModel);
        }
    }
}