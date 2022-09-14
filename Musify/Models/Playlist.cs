using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musify.Models
{
    public class Playlist
    {
        public Playlist()
        {
            PlaylistDetails = new List<PlaylistDetails>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Playlist Name is required")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<PlaylistDetails> PlaylistDetails { get; set; }

    }
}