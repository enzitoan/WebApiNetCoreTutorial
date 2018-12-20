using System;
using System.Collections.Generic;

namespace ChinookCoreAPI.Models
{
    public partial class MediaTypes
    {
        public MediaTypes()
        {
            Tracks = new HashSet<Tracks>();
        }

        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tracks> Tracks { get; set; }
    }
}
