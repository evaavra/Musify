using Musify.Interfaces;
using Musify.Models;
using Musify.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Musify.Areas.Admin.Controllers.api
{
    [Authorize(Roles = "Admin")]
    public class SongsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SongsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            var song = _unitOfWork.Songs.GetById(id);

            if (song == null)
                return NotFound();

            _unitOfWork.Songs.Delete(song);
            _unitOfWork.Complete();

            return Ok();
        }

    }
}
