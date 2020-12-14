using System;
using ADO.NET.Models;
using System.Linq;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateDBData.Generator.generateAll();
        }
    }
}