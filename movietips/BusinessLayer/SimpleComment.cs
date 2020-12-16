using System.Collections.Generic;
using System;
using DataLayer.Models;
using static DataLayer.DBContext;
using System.Collections;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{

    public class SimpleComment
    {
        int id;
        TimeSpan moment;
        public SimpleComment(int _id, TimeSpan _moment)
        {
            id = _id;
            moment = _moment;
        }
        public string getCommentText()
        {
            return dbContext.Comment.FirstOrDefault( c => c.Id == id).Text;
        }
    }
}