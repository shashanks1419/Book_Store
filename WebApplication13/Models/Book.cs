using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class Book
    {

        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }


        public int Position { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }

        public Book()
        {

        }
        public Book(int BId, int CId, string title, string author, int isbn, int year, int price, string Des, int Pos, string status, string Img)
        {
            BookId = BId;
            CategoryId = CId;
            Title = title;
            Author = author;
            ISBN = isbn;
            Year = year;
            Price = price;
            Description = Des;
            Position = Pos;
            Status = status;
            Image = Img;

        }
    }

}