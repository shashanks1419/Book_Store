using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class Wishlist
    {
        public string Username { get; set; }
        public int BookId { get; set; }

        public Wishlist()
        {

        }
        public Wishlist(string uname, int bid)
        {
            Username = uname;
            BookId = bid;

        }
    }
}