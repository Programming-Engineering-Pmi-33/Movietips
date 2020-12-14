using System;
using ADO.NET.Models;
using System.Linq;

namespace ADO.NET.GenerateDBData
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
