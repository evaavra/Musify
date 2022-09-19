using Microsoft.AspNet.Identity;
using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Musify.ViewModels;
using System.Net;

namespace Musify.Controllers
{
    [Authorize]
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
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            if(user.HasPaid == false)
            {
                return RedirectToAction("Index","Payment");
            }
            var playlists = _context.Playlists.Include(p => p.PlaylistDetails.Select(pl => pl.Song));
            var userPlaylists = new List<Playlist>();
            foreach (var pl in playlists)
            {
                if (pl.UserId == userId)
                {
                    userPlaylists.Add(pl);
                }
            }

            var viewmodel = new PlaylistIndexViewModel()
            {
                Playlists = userPlaylists
            };
            return View(viewmodel);
        }

        public ActionResult ListenToPlaylist(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //return RedirectToAction("index");
            }
            var playlist = _context
                .Playlists
                .Include(p => p.PlaylistDetails.Select(pl => pl.Song))
                .SingleOrDefault(p => p.Id == id);
            if (playlist == null)
            {
                return HttpNotFound();
            }

            return View(playlist);
        }

        public ActionResult Create(int? id)
        {
            var playlist = _context.Playlists.Include(p => p.PlaylistDetails.Select(pl => pl.Song)).SingleOrDefault(p => p.Id == id);
            var songs = _context.Songs.ToList();
            var songsInPlaylist = new List<Song>();
            var songsNotInPlaylist = new List<Song>();
            foreach (var song in songs)
            {
                var count = 0;
                foreach (var pldet in playlist.PlaylistDetails)
                {
                    
                    if (song.ID == pldet.SongId){
                        count++;
                        songsInPlaylist.Add(song);
                    }
                }
                if (count == 0)
                {
                    songsNotInPlaylist.Add(song);
                }

            }
            var viewModel = new PlaylistNewViewModel()
            {
                Playlist = playlist,
                SongsInPlaylist = songsInPlaylist,
                SongsNotInPlaylist = songsNotInPlaylist
            };
            return View(viewModel);
        }
    }
}