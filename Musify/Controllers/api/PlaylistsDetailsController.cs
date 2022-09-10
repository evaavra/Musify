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
    public class PlaylistsDetailsController : ApiController
    {
        public ApplicationDbContext _context;

        public PlaylistsDetailsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Create(PlaylistDetailsDto playlistdetailsDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var playlistDetails = new PlaylistDetails()
            {
                SongId = playlistdetailsDto.SongId,
                PlaylistId = playlistdetailsDto.PlaylistId
            };
            _context.PlaylistDetails.Add(playlistDetails);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody] PlaylistDetailsDto playlistdetailsDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var playlistDetailsInDb = _context.PlaylistDetails.SingleOrDefault(p => p.PlaylistId == playlistdetailsDto.PlaylistId && p.SongId == playlistdetailsDto.SongId);

            _context.PlaylistDetails.Remove(playlistDetailsInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
