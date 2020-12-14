using System;
using ADO.NET.Models;
using System.Linq;

namespace ADO.NET.GenerateDBData
{
    static class CommentGenerator
    {
        public static void generate()
        {
            var dbContext = new WebContext();

            for(int i=4;i<52;i++)
            {
                Comment c = new Comment();
                c.Id = i;
                c.UserLogin = "user47";
                c.Timestamp = DateTimeOffset.Now;
                c.Text = "some interesting ref";
                c.MovieId = i;
                dbContext.Comment.Add(c);
            }
            dbContext.SaveChanges();
        }
    }
}
