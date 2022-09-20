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
    public class PlaylistsDetailsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlaylistsDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            _unitOfWork.PlaylistDetails.Create(playlistDetails);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody] PlaylistDetailsDto playlistdetailsDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var playlistDetailsInDb = _unitOfWork.PlaylistDetails.GetByPlaylistAndSongId(playlistdetailsDto.PlaylistId, playlistdetailsDto.SongId);

            _unitOfWork.PlaylistDetails.Delete(playlistDetailsInDb);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
