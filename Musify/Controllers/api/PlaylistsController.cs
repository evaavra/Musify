using Microsoft.AspNet.Identity;
using Musify.Dtos;
using Musify.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public PlaylistsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            _unitOfWork.Playlists.Create(playlist);
            _unitOfWork.Complete();

            return Ok(playlist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var playlist = _unitOfWork.Playlists.GetById(id);

            if (playlist == null)
                return NotFound();

            _unitOfWork.Playlists.Delete(playlist);
            _unitOfWork.Complete();

            return Ok(id);
        }


    }
}

