using System;
using ADO.NET.Models;
using System.Linq;

namespace ADO.NET.GenerateDBData
{
    static class UserGenerator
    {
        public static void generate()
        {
            var dbContext = new WebContext();

            for(int i=4;i<52;i++)
            {
                User u = new User{UserLogin="user"+i.ToString(), EncodedPass="pass",Name="name"+i.ToString(),
                    Status="user"};
                    dbContext.User.Add(u);
                    
            }
            dbContext.SaveChanges();
        }
    }
}
