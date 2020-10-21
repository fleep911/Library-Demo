using AmTrustDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmTrustDemo.Controllers
{
    public class BookController : Controller
    {
        List<Book> books = new List<Book>();
        // GET: Book
        public ActionResult Index()
        {
            DataAccess db = new DataAccess();
            books = db.GetBooks();

            return View(books.ToList());
        }

        // GET: Book by Author
        public ActionResult AuthorIndex()
        {
            DataAccess db = new DataAccess();
            books = db.GetBooksByAuthor();


            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            DataAccess db = new DataAccess();
            books = db.GetBookById(id);
            return View(books.FirstOrDefault());
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            DataAccess db = new DataAccess();
            books = db.GetBookById(id);
            return View(books.FirstOrDefault());
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            DataAccess db = new DataAccess();
            books = db.GetBookById(id);
            return View(books.FirstOrDefault());
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
