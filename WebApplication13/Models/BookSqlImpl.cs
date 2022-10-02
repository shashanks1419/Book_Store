using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;


namespace WebApplication13.Models
{
    public class BookService : IBookRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public BookService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Book AddBook(Book Book)
        {
            comm.Connection = conn;
            conn.Open();
            comm.CommandText = "insert into Book values(" + Book.BookId + "," + Book.CategoryId + ",'" + Book.Title + "','" + Book.Author + "'," + Book.ISBN + "," + Book.Year + "," + Book.Price + ",'" + Book.Description + "'," + Book.Position + ",'" + Book.Status + "','" + Book.Image + "')";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return Book;
            }
            return null;

        }

        public void DeleteBook(int id)
        {
            comm.CommandText = "Delete from Book where BookId=" + id;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Book> GetAllBook()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Book";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bId = Convert.ToInt32(reader["BookId"]);
                int cId = Convert.ToInt32(reader["CategoryId"]);

                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int isbn = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string des = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string status = reader["Status"].ToString();
                string img = reader["Image"].ToString();

                list.Add(new Book(bId, cId, title, author, isbn, year, price, des, pos, status, img));
            }
            conn.Close();
            return list;
        }

        public void UpdateBook(Book cat)
        {
            comm.CommandText = "update Book set Title='" + cat.Title + "',CategoryId=" + cat.CategoryId + ",Author='" + cat.Author + "',ISBN=" + cat.ISBN + ",Year=" + cat.Year + ",Price=" + cat.Price + ",Description='" + cat.Description + "', Position=" + cat.Position + ",Status='" + cat.Status + "',Image='" + cat.Image + "' where BookId=" + cat.BookId;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        List<Book> IBookRepository.GetBookByAuthor(string auth)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Book where Author='" + auth + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bId = Convert.ToInt32(reader["BookId"]);
                int cId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int isbn = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string des = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string status = reader["Status"].ToString();
                string img = reader["Image"].ToString();
                list.Add(new Book(bId, cId, title, auth, isbn, year, price, des, pos, status, img));
            }
            conn.Close();
            return list;
        }

        List<Book> IBookRepository.GetBookByCategory(string CatName)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select BookId,Book.CategoryId,Title,Author,ISBN,Year,Price,Book.Description,Book.Position,Book.Status,Book.Image from Book,Category where Category.CategoryName='" + CatName + "' and Category.CategoryId=Book.CategoryId";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bId = Convert.ToInt32(reader["BookId"]);
                int cId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int isbn = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string des = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string status = reader["Status"].ToString();
                string img = reader["Image"].ToString();
                list.Add(new Book(bId, cId, title, author, isbn, year, price, des, pos, status, img));
            }
            conn.Close();
            return list;
        }

        Book IBookRepository.GetBookByISBN(int Isbn)
        {
            comm.CommandText = "select * from Book where ISBN=" + Isbn;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bId = Convert.ToInt32(reader["BookId"]);
                int cId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int isbn = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string des = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string status = reader["Status"].ToString();
                string img = reader["Image"].ToString();
                Book book = new Book(bId, cId, title, author, isbn, year, price, des, pos, status, img);
                return book;
            }
            return null;


        }

        List<Book> IBookRepository.GetBookByName(string name)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from Book where Title LIKE '%" + name + "%'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bId = Convert.ToInt32(reader["BookId"]);
                int cId = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["Title"].ToString();
                string author = reader["Author"].ToString();
                int isbn = Convert.ToInt32(reader["ISBN"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string des = reader["Description"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string status = reader["Status"].ToString();
                string img = reader["Image"].ToString();
                list.Add(new Book(bId, cId, title, author, isbn, year, price, des, pos, status, img));
            }
            conn.Close();
            return list;
        }
    }
}