using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musify.ViewModels
{
    public class SongFormViewModel
    {
        public List<Album> Albums { get; set; }
        public Song Song { get; set; }

    }
}