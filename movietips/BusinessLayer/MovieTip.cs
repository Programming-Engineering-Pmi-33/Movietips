using DataLayer.Models;
using static DataLayer.DBContext;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLayer
{
    public class MovieTip : SimpleMovieTip
    {
        string text;
        string userLogin;
        int movieId;

        public MovieTip(string _text, string _userLogin, int _movieId, int _millisElapsed) : base(_millisElapsed)
        {
            text = _text;
            userLogin = _userLogin;
            movieId = _movieId;
        }
        public void commitTipToDB()
        {
            var max_id=dbContext.Comment.Max(m => m.Id);
            id = max_id;
            Comment comment = new Comment{Id = max_id, UserLogin = userLogin, MovieId = movieId, Text = text, Timestamp = millisElapsed};
            dbContext.Comment.Add(comment);
            dbContext.SaveChanges();
        }
        
    }
}