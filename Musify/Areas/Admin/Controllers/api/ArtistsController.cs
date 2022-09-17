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
    public class ArtistsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            var artist = _unitOfWork.Artists.GetById(id);

            if (artist == null)
                return NotFound();

            _unitOfWork.Artists.Delete(artist);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
