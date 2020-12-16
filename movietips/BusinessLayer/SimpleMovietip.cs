using System.Collections.Generic;
using System;
using DataLayer.Models;
using static DataLayer.DBContext;
using System.Collections;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class SimpleMovieTip
    {
        protected int id;
        protected int millisElapsed;
        public SimpleMovieTip(int _id, int _moment)
        {
            id = _id;
            millisElapsed = _moment;
        }

        public SimpleMovieTip(int _moment)
        {
            millisElapsed = _moment;
        }
        public string getCommentText()
        {
            return dbContext.Comment.FirstOrDefault( c => c.Id == id).Text;
        }
    }
}