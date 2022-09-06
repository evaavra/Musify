using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musify.Models
{
    public class Album
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Thumbnail { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public List<Song> Songs { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public Album()
        {
            Songs = new List<Song>();
        }
    }
}