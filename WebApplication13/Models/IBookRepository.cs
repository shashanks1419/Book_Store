using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    internal interface IBookRepository
    {
        List<Book> GetAllBook();
        List<Book> GetBookByName(string title);
        Book GetBookByISBN(int isbn);
        List<Book> GetBookByAuthor(string author);
        List<Book> GetBookByCategory(string CatName);

        Book AddBook(Book Book);
        void DeleteBook(int id);
        void UpdateBook(Book cat);
    }
}