using System.Collections.Generic;
using System;
using DataLayer.Models;
using static DataLayer.DBContext;
using System.Collections;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{

    public class Comment
    {
        int id;
        TimeSpan moment;
        public Comment(int _id, TimeSpan _moment)
        {
            id = _id;
            moment = _moment;
        }
        public string getCommentText()
        {
            return dbContext.Comment.FirstOrDefault( c => c.Id == id).Text;
        }
    }

    public class CommentsList
    {
        List<Comment> comments;
        public CommentsList(int movieId)
        {
            List<Comment> cms = dbContext.Comment.Where(c => c.MovieId == movieId).Select(c => new Comment(c.Id, new TimeSpan(c.Timestamp.Ticks))).ToList();
        }
    }
}