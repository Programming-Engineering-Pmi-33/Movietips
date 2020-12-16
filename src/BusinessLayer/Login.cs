using DataLayer.Models;
using static DataLayer.DBContext;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Login
    {
        public static bool user_check(string userlogin_input, string encodedpass_input)
        {
           if(dbContext.User.Any(u => u.UserLogin == userlogin_input))
           {
               User temp_user = dbContext.User.FirstOrDefault(u => u.UserLogin == userlogin_input);
               if(encodedpass_input == temp_user.EncodedPass)
               {
                   return true;
               }
           }
           return false;
        }


    }
}