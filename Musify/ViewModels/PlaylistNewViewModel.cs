using Musify.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Musify.ViewModels
{
    public class PlaylistNewViewModel
    {
        public int PlaylistId { get; set; }

        [Required]
        public string PlaylistName { get; set; }

        public List<Song> Songs { get; set; }
    }
}