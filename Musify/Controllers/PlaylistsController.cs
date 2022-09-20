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
using Musify.Interfaces;

namespace Musify.Controllers
{
    [Authorize]
    public class PlaylistsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlaylistsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Playlists
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.Users.GetUser(userId);
            if (user.HasPaid == false)
            {
                return RedirectToAction("Index", "Payment");
            }
            var playlists = _unitOfWork.Playlists.GetAllWithPlDetailsAndSongs();
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

            var playlist = _unitOfWork.Playlists.GetByIdWithPlDetailsAndSongs(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }

            return View(playlist);
        }

        public ActionResult Create(int? id)
        {
            var playlist = _unitOfWork.Playlists.GetByIdWithPlDetailsAndSongs(id);
            var songs = _unitOfWork.Songs.GetAll().ToList();
            var songsInPlaylist = new List<Song>();
            var songsNotInPlaylist = new List<Song>();
            foreach (var song in songs)
            {
                var count = 0;
                foreach (var pldet in playlist.PlaylistDetails)
                {

                    if (song.ID == pldet.SongId)
                    {
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