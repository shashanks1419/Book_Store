using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WebApplication13.Models
{
    public class CartService : ICartRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public CartService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Cart AddtoCart(Cart cart)
        {
            comm.CommandText = "insert into Cart values('" + cart.Username + "'," + cart.BookId + "," + cart.Quantity + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            if (row > 0)
            {

                return cart;
            }
            return null;
        }

        public void DeletefromCart(string uname, int bid)
        {
            comm.CommandText = "Delete from Cart where Username='" + uname + "' and BookId=" + bid;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
        }



        public List<Cart> ViewCart()
        {
            List<Cart> list = new List<Cart>();
            comm.CommandText = "select * from Cart";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {


                string username = reader["Username"].ToString();
                int bid = Convert.ToInt32(reader["BookId"]);
                int qty = Convert.ToInt32(reader["Quantity"]);
                list.Add(new Cart(username, bid, qty));
            }
            conn.Close();
            return list;
        }
    }
}