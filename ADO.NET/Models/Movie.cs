using System;
using System.Collections.Generic;

namespace ADO.NET.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Comment = new HashSet<Comment>();
            MovieRate = new HashSet<MovieRate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int LenInSec { get; set; }

        public ICollection<Comment> Comment { get; set; }
        public ICollection<MovieRate> MovieRate { get; set; }
    }
}
