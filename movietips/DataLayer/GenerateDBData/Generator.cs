using System;
using DataLayer.Models;
using System.Linq;

namespace DataLayer.GenerateDBData
{
    static class Generator
    {
        public static void generateAll()
        {
            GenerateDBData.UserGenerator.generate();
            GenerateDBData.MovieGenerator.generate();
            GenerateDBData.CommentGenerator.generate();
            GenerateDBData.CommentRateGenerator.generate();
            GenerateDBData.MovieRateGenerator.generate();
        }
    }
}
