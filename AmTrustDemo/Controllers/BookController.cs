using AmTrustDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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
            DataAccess db = new DataAccess();
            List<Author> authors = new List<Author>();
            var authorList = db.GetAuthor();
            ViewBag.AuthorId = new SelectList(authorList, "Id", "AuthorLastName");
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(string BookName, int AuthorId)
        {
            try
            {
                DataAccess db = new DataAccess();
                books = db.BookCreate(BookName, AuthorId);
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

            List<Author> authors = new List<Author>();
            var authorList = db.GetAuthor();
            ViewBag.AuthorId = new SelectList(authorList, "Id", "AuthorLastName" );

            return View(books.FirstOrDefault());
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string BookName, int AuthorId)
        {
            try
            {
                List<Book> books = new List<Book>();
                DataAccess db = new DataAccess();
                books = db.BookUpdate(id, BookName, AuthorId);
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
        public ActionResult Delete(int id, string delete)
        {
            try
            {
                DataAccess db = new DataAccess();
                db.BookDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
