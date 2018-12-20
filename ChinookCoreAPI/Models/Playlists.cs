using System;
using System.Collections.Generic;

namespace ChinookCoreAPI.Models
{
    public partial class Playlists
    {
        public Playlists()
        {
            FkPlaylistTrackPlaylistId = new HashSet<FkPlaylistTrackPlaylistId>();
        }

        public int PlaylistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FkPlaylistTrackPlaylistId> FkPlaylistTrackPlaylistId { get; set; }
    }
}
