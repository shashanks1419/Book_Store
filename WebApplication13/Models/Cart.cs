using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class Cart
    {
        public string Username { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public Cart()
        {

        }
        public Cart(string uname, int bid, int qty)
        {
            Username = uname;
            BookId = bid;
            Quantity = qty;
        }
    }

}