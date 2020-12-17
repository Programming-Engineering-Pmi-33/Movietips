using System;
using DataLayer.Models;
using System.Linq;

namespace DataLayer.GenerateDBData
{
    static class MovieGenerator
    {
        public static void generate()
        {
            var dbContext = new WebContext();

            for(int i = 4; i < 52; i++)
            {
                Movie m = new Movie();
                m.Id = i;
                m.LenInSec = 1000;
                m.Name = "Movie_" + i.ToString();

                dbContext.Movie.Add(m);
            }
            dbContext.SaveChanges();
        }
    }
}
