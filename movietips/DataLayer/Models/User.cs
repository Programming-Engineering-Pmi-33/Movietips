using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            CommentRate = new HashSet<CommentRate>();
            MovieRate = new HashSet<MovieRate>();
        }

        public string UserLogin { get; set; }
        public string EncodedPass { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public ICollection<Comment> Comment { get; set; }
        public ICollection<CommentRate> CommentRate { get; set; }
        public ICollection<MovieRate> MovieRate { get; set; }
    }
}
