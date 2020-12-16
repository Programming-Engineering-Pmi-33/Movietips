using DataLayer.Models;
using static DataLayer.DBContext;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Login
    {
        string username;
        bool loggedIn;
        string status;
        public Login()
        {
            username = "";
            loggedIn = false;
            status  = "";
        }

        public Login(string _status)
        {
            status = _status;
            username = "";
            loggedIn = false;
        }

        public Login(string _username, string password)
        {
            status = "login failed";
            username = _username;
            loggedIn = false;
            user_check(username, password);
        }

        public bool user_check(string userlogin_input, string encodedpass_input)
        {
           if(dbContext.User.Any(u => u.UserLogin == userlogin_input))
           {
               User temp_user = dbContext.User.FirstOrDefault(u => u.UserLogin == userlogin_input);
               if(encodedpass_input == temp_user.EncodedPass)
               {
                   username = userlogin_input;
                   loggedIn = true;
                   status = "ok";
                   return true;
               }
           }
           return false;
        }
    }
}