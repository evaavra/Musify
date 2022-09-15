using Microsoft.AspNet.Identity;
using Musify.Dtos;
using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Musify.Controllers.api
{
    public class PlaylistsController : ApiController
    {
        public ApplicationDbContext _context;

        public PlaylistsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Create(PlaylistDto playlistDto)
        {
            var userId = User.Identity.GetUserId();
            Console.WriteLine("HEllo");
            if (!ModelState.IsValid)
                return BadRequest();

            var playlist = new Playlist()
            {
                Name = playlistDto.Name,
                UserId = userId
            };
            _context.Playlists.Add(playlist);
            _context.SaveChanges();

            return Ok(playlist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var playlist = _context.Playlists.SingleOrDefault(p => p.Id == id);

            if (playlist == null)
                return NotFound();

            _context.Playlists.Remove(playlist);
            _context.SaveChanges();

            return Ok(id);
        }


    }
}

