using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public string Location { get; set; }
        public int CouponId { get; set; }
        public string Status { get; set; }
        public Order()
        {

        }
        public Order(int oid, string uname, int bid, int qty, string location, int cid, string status)
        {
            OrderId = oid;
            UserName = uname;
            BookId = bid;
            Quantity = qty;
            Location = location;
            CouponId = cid;
            Status = status;
        }
    }
}