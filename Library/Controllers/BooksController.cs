using Library.Models;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace Library.Controllers
{
    public class BooksController : Controller
    {

        private readonly LibraryDbContext db;
        public BooksController()
        {
            db = new LibraryDbContext();
        }
        // GET: Books
        public ActionResult Index()
        {
            var data = db.Books.Include(m=>m.Category).ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            var ViewModel = new BookVM
            {
                Categories = db.Categories.Where(m=>m.IsActive).ToList()
            };
            return View("BookForm", ViewModel);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = db.Books.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }

            var ViewModel = new BookVM
            {
                Id = data.Id,
                Name = data.Name,
                Author = data.Author,
                CategoryId = data.CategoryId,
                Descreption = data.Descreption,
                Categories = db.Categories.Where(m => m.IsActive).ToList()
            };

            return View("BookForm", ViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( BookVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = db.Categories.Where(m => m.IsActive).ToList();
                return View("BookForm", model);
            }

            if (model.Id == 0)
            {
                var data = new Book
                {
                    Name = model.Name,
                    Author = model.Author,
                    CategoryId = model.CategoryId,
                    Descreption = model.Descreption

                };
                db.Books.Add(data);
            }
            else
            {
                var data = db.Books.Find(model.Id);
                if (data==null)
                {
                    return HttpNotFound();
                }

                data.Name = model.Name;
                data.Author = model.Author;
                data.CategoryId = model.CategoryId;
                data.Descreption = model.Descreption;
            }
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

        public ActionResult details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var data = db.Books.Include(m => m.Category).SingleOrDefault(m => m.Id==id);
            if (data == null)
            {
                return HttpNotFound();

            }
            return View(data);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var data = db.Books.Include(m => m.Category).SingleOrDefault(m => m.Id == id);
            if (data == null)
            {
                return HttpNotFound();

            }
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            var data = db.Books.Find(id);

            if (data == null)
            {
                return HttpNotFound();
            }
            db.Books.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}