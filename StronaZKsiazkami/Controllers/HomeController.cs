using StronaZKsiazkami.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;

namespace StronaZKsiazkami.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddBook()
        {
            ViewBag.Message = "Adding a new book to DB";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(BookModel model)
        {
            if(ModelState.IsValid)
            {
                BookProcessor.CrateBook(model.Title, model.AuthorFirstName, model.AuthorLastName, model.Description, model.Price, model.Amount);
                return RedirectToAction("index");
            }

            return View();
        }

        public ActionResult ViewAllBooks()
        {
            ViewBag.Message = "List of all books.";
            
            var data = BookProcessor.LoadBooks();
            List<BookModel> books = new List<BookModel>();

            foreach (var book in data)
            {
                books.Add(new BookModel
                {
                    Title = book.Title,
                    AuthorFirstName = book.Author_first_name,
                    AuthorLastName = book.Author_last_name,
                    Description = book.Short_desc,
                    Amount = book.Amount,
                    Price = book.Price
                }
                    );
            }

            return View(books);
        }


    }
}