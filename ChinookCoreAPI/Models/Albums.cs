using System;
using System.Collections.Generic;

namespace ChinookCoreAPI.Models
{
    public partial class Albums
    {
        public Albums()
        {
            Tracks = new HashSet<Tracks>();
        }

        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistArtistId { get; set; }

        public virtual Artists ArtistArtist { get; set; }
        public virtual ICollection<Tracks> Tracks { get; set; }
    }
}
