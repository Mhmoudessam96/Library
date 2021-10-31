using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Controllers.API
{
    public class BooksController : ApiController
    {
        private readonly LibraryDbContext db;
        public BooksController()
        {
            db = new LibraryDbContext();
        }
        [HttpDelete]
        IHttpActionResult DeleteBook(int id)
        {
            var data = db.Books.Find(id);

            if (data == null)
            {
                return NotFound();
            }
            db.Books.Remove(data);
            db.SaveChanges();
            return Ok();
        }
    }
}
