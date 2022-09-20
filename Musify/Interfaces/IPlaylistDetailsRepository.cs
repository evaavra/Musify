using Musify.Models;

namespace Musify.Interfaces
{
    public interface IPlaylistDetailsRepository
    {
        void Create(PlaylistDetails playlistDetails);
        void Delete(PlaylistDetails playlistDetails);
        PlaylistDetails GetByPlaylistAndSongId(int playlistId, int songId);
    }
}