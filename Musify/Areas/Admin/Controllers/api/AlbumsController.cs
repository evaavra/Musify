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
    public class AlbumsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlbumsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            var album = _unitOfWork.Albums.GetById(id);

            if (album == null)
                return NotFound();

            _unitOfWork.Albums.Delete(album);

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
