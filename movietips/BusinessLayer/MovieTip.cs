using DataLayer.Models;
using static DataLayer.DBContext;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLayer
{
    public class MovieTip
    {
        string text;
        TimeSpan timestamp;
        string userLogin;
        int movieId;


        public MovieTip(string _text, TimeSpan _timestamp, string _userLogin, int _movieId)
        {
            text = _text;
            timestamp = _timestamp;
            userLogin = _userLogin;
            movieId = _movieId;
        }
        public void commitTip()
        {
            var max_id=dbContext.Comment.Max(m => m.Id);
            Comment comment = new Comment{Id = max_id, UserLogin = userLogin, MovieId = movieId, Text = text, Timestamp = new DateTimeOffset.ToOffset(timestamp))};
            dbContext.User.Add(new_user); 
            dbContext.SaveChanges();
            return new Login(userlogin_input, encodedpass_input);
        }
        
    }
}