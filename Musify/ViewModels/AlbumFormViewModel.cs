using Musify.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musify.ViewModels
{

        public class AlbumFormViewModel
        {
            public int ID { get; set; }

            [Required(ErrorMessage = "Title is required")]
            [StringLength(60, MinimumLength = 3)]
            public string Title { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Thumbnail { get; set; }

            public int GenreId { get; set; }

            public HttpPostedFileBase ImageFile { get; set; }

            public int ArtistId { get; set; }

            public List<Artist> Artists { get; set; }

            public List<Genre> Genres { get; set; }

            public AlbumFormViewModel()
            {
                ReleaseDate = new DateTime();
            }

            public string Action
            {
                get
                {
                    return (ID != 0) ? "Edit" : "Create";
                }
            }

            public string Heading { get; set; }
        }
    
}