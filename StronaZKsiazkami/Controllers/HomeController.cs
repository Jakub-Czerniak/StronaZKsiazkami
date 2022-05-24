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

        public ActionResult BookDetails(int id)
        {
            var data = BookProcessor.LoadBook(id);
            BookModel Book = new BookModel();

            if(data.Count()==0)
                return View("index");

            Book.Id = data[0].Id;
            Book.Title = data[0].Title;
            Book.AuthorFirstName = data[0].Author_first_name;
            Book.AuthorLastName = data[0].Author_last_name;
            Book.Description = data[0].Short_desc;
            Book.Price = data[0].Price;
            Book.Amount = data[0].Amount;

            return View(Book);
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
                    Id = book.Id,
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

        public ActionResult AddToCart(int id)
        {
            var data = BookProcessor.LoadBook(id);
            CartItemModel model = new CartItemModel();
            bool found = false;

            if (Session["cart"] == null)
            {
                List<CartItemModel> cartItems = new List<CartItemModel>();
                cartItems.Add(new CartItemModel 
                {
                    BookId = data[0].Id,
                    Title = data[0].Title,
                    Count = 1,
                    Total = data[0].Price
                }                    
                    );
                Session["cart"] = cartItems;
            }
            else
            {
                List<CartItemModel> cartItems = (List<CartItemModel>)Session["cart"];
                foreach (var item in cartItems)
                {
                    if (item.BookId == id)
                    {
                        item.Count += 1;
                        item.Total +=data[0].Price;
                        found = true;
                        break;
                    }
                }
                if (!found) 
                {
                    cartItems.Add(new CartItemModel
                    {
                        BookId = data[0].Id,
                        Title = data[0].Title,
                        Count = 1,
                        Total = data[0].Price
                    }
                    );
                }

                Session["cart"] = cartItems;
            }

            return RedirectToAction("ViewAllBooks");
        }

        public ActionResult Cart()
        {
            ViewBag.Message = "Your shopping cart.";

            if (Session["cart"] == null)
                return RedirectToAction("ViewAllBooks");
            return View(Session["cart"]);
        }
        
    }
}