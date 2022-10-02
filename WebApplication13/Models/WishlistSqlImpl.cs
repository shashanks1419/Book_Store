using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class WishlistService : IWishlistRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public WishlistService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Wishlist AddtoWishlist(Wishlist wishlist)
        {
            comm.CommandText = "insert into Wishlist values('" + wishlist.Username + "'," + wishlist.BookId + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            if (row > 0)
            {

                return wishlist;
            }
            return null;
        }

        public void DeletefromWishlist(string uname, int bid)
        {
            comm.CommandText = "Delete from Wishlist where Username='" + uname + "' and BookId=" + bid;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
        }



        public List<Wishlist> ViewWishlist()
        {
            List<Wishlist> list = new List<Wishlist>();
            comm.CommandText = "select * from Wishlist";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {


                string username = reader["Username"].ToString();
                int bid = Convert.ToInt32(reader["BookId"]);

                list.Add(new Wishlist(username, bid));
            }
            conn.Close();
            return list;
        }
    }
}