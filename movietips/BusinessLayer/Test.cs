using System;
namespace BusinessLayer
{
    public static class Test
    {
        public static void Main(string[] args)
        {
            CommentsList com = new CommentsList(5);
            
            Console.Write(com.comments[0].getCommentText());
            
        }
    }
}