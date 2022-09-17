using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musify.ViewModels
{
    public class SongsDetailsViewModel
    {
        public List<Song> Songs { get; set; }

        public string SearchTerm { get; set; }
    }
}