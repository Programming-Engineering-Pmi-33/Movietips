using System;

namespace BusinessLayer
{
    public static class Test
    {
        public static void Main(string[] args)
        {
            MovieTip mt = new MovieTip("haha nice joke", "yura", 7, 47);
            mt.commitTipToDB();
        }
    }
}