using AmTrustDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace AmTrustDemo.Controllers
{
    public class AuthorController : Controller
    {
        List<Author> authors = new List<Author>();
        // GET: Author
        public ActionResult Index()
        {
            DataAccess db = new DataAccess();
            authors = db.GetAuthor();

            return View(authors.ToList());
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            DataAccess db = new DataAccess();
            authors = db.GetAuthorById(id);
            return View(authors.FirstOrDefault());
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(string AuthorFirstName, string AuthorLastName)
        {
            try
            {
                DataAccess db = new DataAccess();
                authors = db.AuthorCreate(AuthorFirstName, AuthorLastName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            DataAccess db = new DataAccess();
            authors = db.GetAuthorById(id);
            return View(authors.FirstOrDefault());
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string AuthorFirstName, string AuthorLastName)
        {
            try
            {
                // TODO: Add update logic here
                DataAccess db = new DataAccess();
                authors = db.AuthorUpdate(id, AuthorFirstName, AuthorLastName);

                return RedirectToAction("Index");


            }
            catch (Exception e )
            {
                
                
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            DataAccess db = new DataAccess();
            authors = db.GetAuthorById(id);
            return View(authors.FirstOrDefault());
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string delete)
        {
            try
            {
                // TODO: Add delete logic here

                DataAccess db = new DataAccess();

                db.AuthorDelete(id);


                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
