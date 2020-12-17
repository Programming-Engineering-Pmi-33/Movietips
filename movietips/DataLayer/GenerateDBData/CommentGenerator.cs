using System;
using DataLayer.Models;
using System.Linq;

namespace DataLayer.GenerateDBData
{
    static class CommentGenerator
    {
        public static void generate()
        {
            var dbContext = new WebContext();

            for(int i = 4; i < 52; i++)
            {
                Comment c = new Comment();
                c.Id = i;
                c.UserLogin = "user47";
                c.Timestamp = 0;
                c.Text = "some interesting ref";
                c.MovieId = i;
                dbContext.Comment.Add(c);
            }
            dbContext.SaveChanges();
        }
    }
}
