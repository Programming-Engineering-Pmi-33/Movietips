using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Comment
    {
        public Comment()
        {
            CommentRate = new HashSet<CommentRate>();
        }

        public int Id { get; set; }
        public string UserLogin { get; set; }
        public int MovieId { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public Movie Movie { get; set; }
        public User UserLoginNavigation { get; set; }
        public ICollection<CommentRate> CommentRate { get; set; }
    }
}
