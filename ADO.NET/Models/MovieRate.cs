using System;
using System.Collections.Generic;

namespace ADO.NET.Models
{
    public partial class MovieRate
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public int MovieId { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }

        public Movie Movie { get; set; }
        public User UserLoginNavigation { get; set; }
    }
}
