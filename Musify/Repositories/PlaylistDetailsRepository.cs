using Musify.Interfaces;
using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musify.Repositories
{
    public class PlaylistDetailsRepository : IPlaylistDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public PlaylistDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PlaylistDetails GetByPlaylistAndSongId(int playlistId, int songId)
        {
            return _context.PlaylistDetails
                .SingleOrDefault(p => p.PlaylistId == playlistId && p.SongId == songId);
        }

        public void Create(PlaylistDetails playlistDetails)
        {
            _context.PlaylistDetails.Add(playlistDetails);
        }

        public void Delete(PlaylistDetails playlistDetails)
        {
            _context.PlaylistDetails.Remove(playlistDetails);
        }
    }
}