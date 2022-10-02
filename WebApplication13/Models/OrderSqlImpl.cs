using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class OrderService : IOrderRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public OrderService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();

        }
        public Order AddOrder(Order order)
        {
            comm.CommandText = "insert into Orders values(" + order.OrderId + ",'" + order.UserName + "'," + order.BookId + "," + order.Quantity + ",'" + order.Location + "'," + order.CouponId + ",'" + order.Status + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return order;
            }
            return null;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> list = new List<Order>();
            comm.CommandText = "select * from Orders";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int oid = Convert.ToInt32(reader["OrderId"]);
                string name = (reader["UserName"]).ToString();
                int bid = Convert.ToInt32(reader["BookId"]);
                int qty = Convert.ToInt32(reader["Quantity"]);
                string location = (reader["Location"]).ToString();
                int cid = Convert.ToInt32(reader["CouponId"]);
                string status = (reader["Status"]).ToString();

                list.Add(new Order(oid, name, bid, qty, location, cid, status));




            }
            conn.Close();
            return list;

        }

        public int GetOrderPrice(Order order)
        {
            int tprice = 0;
            comm.CommandText = "select Book.Price,Orders.Quantity from Book join Orders on Book.BookId=Orders.BookId where Orders.OrderId=" + order.OrderId;

            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();


            while (reader.Read())
            {
                int price = Convert.ToInt32(reader["Price"]);
                int qty = Convert.ToInt32(reader["Quantity"]);
                tprice = price * qty;
            }
            conn.Close();
            comm.CommandText = "select Discount from Coupon where CouponId=" + order.CouponId;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader1 = comm.ExecuteReader();
            while (reader1.Read())
            {
                int discount = Convert.ToInt32(reader1["Discount"]);
                tprice = tprice - discount;
            }
            conn.Close();
            return tprice;
        }

        public void OrderStatus(string status, int OrderId)
        {
            comm.CommandText = "update Orders set  Status ='" + status + "' where OrderId=" + OrderId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}