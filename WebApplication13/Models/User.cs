using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication13.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Status { get; set; }
        public User()
        {

        }
        public User(string username, string password, string mobile, string status)
        {
            UserName = username;
            Password = password;
            Mobile = mobile;
            Status = status;
        }
    }
}