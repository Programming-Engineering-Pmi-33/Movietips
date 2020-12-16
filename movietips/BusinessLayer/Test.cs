using System;

namespace BusinessLayer
{
    public static class Test
    {
        public static void Main(string[] args)
        {
            Movie nm = new Movie("movie_10");
            Console.WriteLine(nm.comments[0].getCommentText());
        }
    }
}