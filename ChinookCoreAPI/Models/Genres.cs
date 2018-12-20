﻿using System;
using System.Collections.Generic;

namespace ChinookCoreAPI.Models
{
    public partial class Genres
    {
        public Genres()
        {
            Tracks = new HashSet<Tracks>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tracks> Tracks { get; set; }
    }
}
