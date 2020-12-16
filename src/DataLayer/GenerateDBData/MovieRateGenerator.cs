using System;
using DataLayer.Models;
using System.Linq;

namespace DataLayer.GenerateDBData
{
    static class MovieRateGenerator
    {
        public static void generate()
        {
            var dbContext = new WebContext();

            for(int i=4;i<52;i++)
            {
                MovieRate mr = new MovieRate();
                mr.Rate = i%5 + 1;
                mr.MovieId = 47;
                mr.Id = i;
                mr.Comment = "my rate is the only true rate";
                mr.UserLogin = "user" + i.ToString();
                dbContext.MovieRate.Add(mr);
                
            }
            dbContext.SaveChanges();
        }
    }
}
