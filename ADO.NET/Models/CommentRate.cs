using System;
using System.Collections.Generic;

namespace ADO.NET.Models
{
    public partial class CommentRate
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public int CommentId { get; set; }
        public int Rate { get; set; }

        public Comment Comment { get; set; }
        public User UserLoginNavigation { get; set; }
    }
}
