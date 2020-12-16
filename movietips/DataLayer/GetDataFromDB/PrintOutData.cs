using System;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.GetDataFromDB
{
    public static class PrintOutData
    {
        public static void print()
        {
            var dbContext = new WebContext();

            var users = dbContext.User.ToList();
            var movies = dbContext.Movie.ToList();
            var movies_rates = dbContext.MovieRate.ToList();
            var comments = dbContext.Comment.ToList();
            var comments_rates = dbContext.CommentRate.ToList();


            Console.WriteLine("###Users###");
            foreach (var u in users)
            {
                Console.WriteLine(u.UserLogin + " " + u.EncodedPass + " " + u.Name + " " + u.Status);

            }
            Console.WriteLine("");
            Console.WriteLine("###Movies###");
            foreach (var m in movies)
            {
                Console.WriteLine(m.Id + " " + m.Name + " " + m.LenInSec);

            }
            Console.WriteLine("");
            Console.WriteLine("###MoviesRates###");
            foreach (var mr in movies_rates)
            {
                Console.WriteLine(mr.Id + " " + mr.UserLogin + " " + mr.MovieId + " " + mr.Rate + " " + mr.Comment);

            }
            Console.WriteLine("");
            Console.WriteLine("###Comments###");
            foreach (var c in comments)
            {
                Console.WriteLine(c.Id + " " + c.UserLogin + " " + c.MovieId + " " + c.Text + " " + c.Timestamp);

            }
            Console.WriteLine("");
            Console.WriteLine("###Comments_rates###");
            foreach (var cr in comments_rates)
            {
                Console.WriteLine(cr.Id + " " + cr.UserLogin + " " + cr.CommentId + " " + cr.Rate);

            }
        }
    }
}