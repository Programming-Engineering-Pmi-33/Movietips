using DataLayer.Models;
using static DataLayer.DBContext;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLayer
{
    public class Registration
    {
        public static bool registrate(string userlogin_input, string encodedpass_input, string name_input)
        {
            if(dbContext.User.Any(u => u.UserLogin == userlogin_input))
            {
                return false;
            }else{
                User new_user = new User{UserLogin = userlogin_input, EncodedPass = encodedpass_input, Name = name_input, Status = "user"};
                dbContext.User.Add(new_user); 
            }
            dbContext.SaveChanges();
            return true;
        }
    }
}