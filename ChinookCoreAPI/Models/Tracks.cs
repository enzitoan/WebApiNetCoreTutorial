using System;
using System.Collections.Generic;

namespace ChinookCoreAPI.Models
{
    public partial class Tracks
    {
        public Tracks()
        {
            FkPlaylistTrackPlaylistId = new HashSet<FkPlaylistTrackPlaylistId>();
            InvoiceLines = new HashSet<InvoiceLines>();
        }

        public int TrackId { get; set; }
        public string Name { get; set; }
        public string Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }
        public int? AlbumAlbumId { get; set; }
        public int? GenreGenreId { get; set; }
        public int MediaTypeMediaTypeId { get; set; }

        public virtual Albums AlbumAlbum { get; set; }
        public virtual Genres GenreGenre { get; set; }
        public virtual MediaTypes MediaTypeMediaType { get; set; }
        public virtual ICollection<FkPlaylistTrackPlaylistId> FkPlaylistTrackPlaylistId { get; set; }
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
    }
}
