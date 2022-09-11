using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musify.Models
{
    public class Artist
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Artist Name is required.")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        public string Thumbnail { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public List<Album> Albums { get; set; }
        public string Info { get; set; }

        public Artist()
        {
            Albums = new List<Album>();
        }
    }
}