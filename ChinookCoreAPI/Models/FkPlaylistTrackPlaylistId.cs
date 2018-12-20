using System;
using System.Collections.Generic;

namespace ChinookCoreAPI.Models
{
    public partial class FkPlaylistTrackPlaylistId
    {
        public int PlaylistsPlaylistId { get; set; }
        public int TracksTrackId { get; set; }

        public virtual Playlists PlaylistsPlaylist { get; set; }
        public virtual Tracks TracksTrack { get; set; }
    }
}
