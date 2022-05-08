using FPTApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;


namespace FPTApp.Controllers
{
    public class HomeController : Controller
    {
        private FPTDBContext fptDB = new FPTDBContext();
        // GET: Home
        public ActionResult Index(string SearchString = "")
        {
            if(SearchString != "")
            {
                var sach = fptDB.Books.Where(x => x.BookName.ToUpper().Contains(SearchString.ToUpper()));
            }
            return View(fptDB.Books.ToList());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = fptDB.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        public ActionResult Create()
        {
            Book book = new Book();
            return View(book);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,BookName,ImageUpload,BookPrice")] Book book)
        {
           
            try
            {
                if (book.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(book.ImageUpload.FileName);
                    string extension = Path.GetExtension(book.ImageUpload.FileName);
                    fileName = fileName + extension;
                    book.ImagePath = "~/Publish/Images/" + fileName;
                    book.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Publish/Images/"), fileName));
                }

                book.BookID = Guid.NewGuid();
                fptDB.Books.Add(book);
                fptDB.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = fptDB.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,BookName,ImageUpload,BookPrice")] Book book)
        {
            if (ModelState.IsValid)
            {
                fptDB.Entry(book).State = EntityState.Modified;
                fptDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = fptDB.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Book book = fptDB.Books.Find(id);
            fptDB.Books.Remove(book);
            fptDB.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                fptDB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}