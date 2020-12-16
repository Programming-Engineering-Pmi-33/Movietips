using System;
using DataLayer.Models;
using System.Linq;

namespace DataLayer.GenerateDBData
{
    static class CommentRateGenerator
    {
        public static void generate()
        {
            var dbContext = new WebContext();

            for(int i=4;i<52;i++)
            {
                CommentRate cr = new CommentRate();
                cr.Id = i;
                cr.Rate = (i%2==0?-1:1);
                cr.UserLogin = "user"+i.ToString();
                cr.CommentId = i;
                dbContext.CommentRate.Add(cr);
            }
            dbContext.SaveChanges();
        }
    }
}
