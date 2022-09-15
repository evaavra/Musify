using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musify.ViewModels
{
    public class AllDataViewModel
    {
        public List<Artist> Artists { get; set; }

        public List<Album> Albums { get; set; }

        public List<Song> Songs { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public List<ApplicationUser> UsersHavePaid { get; set; }

        public List<ApplicationUser> UsersHaveNotPaid { get; set; }
    }
}