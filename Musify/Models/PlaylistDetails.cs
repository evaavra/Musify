using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musify.Models
{
    public class PlaylistDetails
    {
        [Key]
        [Column(Order = 1)]
        public int PlaylistId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int SongId { get; set; }

        public Playlist Playlist { get; set; }
        public Song Song { get; set; }
    }
}