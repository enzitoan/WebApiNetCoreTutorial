using System;
using System.Collections.Generic;

namespace ChinookCoreAPI.Models
{
    public partial class Artists
    {
        public Artists()
        {
            Albums = new HashSet<Albums>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Albums> Albums { get; set; }
    }
}
