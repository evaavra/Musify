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
        public Playlist Playlist { get; set; }

        public List<Song> SongsInPlaylist { get; set; }

        public List<Song> SongsNotInPlaylist { get; set; }
    }
}