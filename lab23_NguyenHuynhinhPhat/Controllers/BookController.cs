using lab23_NguyenHuynhinhPhat.Models;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XAct.Library.Settings;


namespace lab23_NguyenHuynhinhPhat.Controllers
{
    public class BookController : Controller
    {
        
        // GET: Book
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML CSS");
            books.Add("JVS Reacts");
            books.Add("Book2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML CSS", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML CSS JS", "Author Name Book 1", "/Content/Images/book2cover.jpeg"));
            books.Add(new Book(3, "HTML CSS SJ BOOSTRAP", "Author Name Book 1", "/Content/Images/book3cover.jpeg"));

            return View(books);
        }
        [HttpGet]
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML CSS", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML CSS JS", "Author Name Book 1", "/Content/Images/book2cover.jpeg"));
            books.Add(new Book(3, "HTML CSS SJ BOOSTRAP", "Author Name Book 1", "/Content/Images/book3cover.jpeg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Tittle, string Author, string Imagecover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML CSS", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML CSS JS", "Author Name Book 1", "/Content/Images/book2cover.jpeg"));
            books.Add(new Book(3, "HTML CSS SJ BOOSTRAP", "Author Name Book 1", "/Content/Images/book3cover.jpeg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Tittle;
                    b.Author = Author;
                    b.Image_cover = Imagecover;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("ListBookModel", books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML CSS", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML CSS JS", "Author Name Book 1", "/Content/Images/book2cover.jpeg"));
            books.Add(new Book(3, "HTML CSS SJ BOOSTRAP", "Author Name Book 1", "/Content/Images/book3cover.jpeg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
        public ActionResult DeleteBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML CSS", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML CSS JS", "Author Name Book 1", "/Content/Images/book2cover.jpeg"));
            books.Add(new Book(3, "HTML CSS SJ BOOSTRAP", "Author Name Book 1", "/Content/Images/book3cover.jpeg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Link/Delete/5
        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML CSS", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML CSS JS", "Author Name Book 1", "/Content/Images/book2cover.jpeg"));
            books.Add(new Book(3, "HTML CSS SJ BOOSTRAP", "Author Name Book 1", "/Content/Images/book3cover.jpeg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (books != null)
            {
                books.Remove(book);
                
            }
            return View("ListBookModel", books);
        }
    }

}