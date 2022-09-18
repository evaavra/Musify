using Musify.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musify.ViewModels
{
    public class PlaylistIndexViewModel
    {
        public int PlaylistId { get; set; }

        [Required]
        public string PlaylistName { get; set; }

        public List<Playlist> Playlists { get; set; }

    }
}