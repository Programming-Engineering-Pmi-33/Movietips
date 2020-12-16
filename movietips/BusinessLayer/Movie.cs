using DataLayer.Models;
using static DataLayer.DBContext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Movie
    {
        int id;
        public List<SimpleMovieTip> comments;    
        public Movie(string moviename_input, int leninsec = 0)
        {
            if(dbContext.Movie.Any(m => m.Name == moviename_input))
            {
                id = dbContext.Movie.FirstOrDefault(m => m.Name == moviename_input).Id;
            }else{
                var max_id=dbContext.Movie.Max(m => m.Id);
                
                DataLayer.Models.Movie new_movie = new DataLayer.Models.Movie{Id = max_id+1, Name = moviename_input, LenInSec = leninsec  };
                dbContext.Movie.Add(new_movie);
                dbContext.SaveChanges(); 
                id = max_id+1;
            }
            comments = dbContext.Comment.Where(c => c.MovieId == id).Select(c => new SimpleMovieTip(c.Id, c.Timestamp)).ToList();

        }
    }
}