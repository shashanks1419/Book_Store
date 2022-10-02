using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class BookController : ApiController
    {
        private IBookRepository Book;
        public BookController()
        {
            Book = new BookService();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = Book.GetAllBook();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Book cat)
        {
            var data = Book.AddBook(cat);
            return Ok(data);

        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Book.DeleteBook(id);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(Book cat)
        {
            Book.UpdateBook(cat);
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get(string auth)
        {
            var data = Book.GetBookByAuthor(auth);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int isbn)
        {
            var data = Book.GetBookByISBN(isbn);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get2(string CatName)
        {
            var data = Book.GetBookByCategory(CatName);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get3(string name)
        {
            var data = Book.GetBookByName(name);
            return Ok(data);
        }

    }
}
