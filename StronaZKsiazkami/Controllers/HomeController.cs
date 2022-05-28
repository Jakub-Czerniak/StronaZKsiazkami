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
            if (ModelState.IsValid)
            {
                BookProcessor.CrateBook(model.Title, model.AuthorFirstName, model.AuthorLastName, model.Description, model.Price, model.Amount, model.Genre_name);
                return RedirectToAction("index");
            }

            return View();
        }
        public ActionResult AddReview(int id)
        {
            ReviewModel Review = new ReviewModel();
            Review.BookId = id;

            ViewBag.Message = "Adding a new review to DB";

            return View(Review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(ReviewModel model)
        {
            if (ModelState.IsValid)
            {
                ReviewProcessor.CreateReview(model.TextReview, model.Rating, model.Username, model.BookId);
                return RedirectToAction("index");
            }

            return View();
        }

        public ActionResult BookDetails(int id)
        {
            var data = BookProcessor.LoadBook(id);
            BookModel Book = new BookModel();

            if (data.Count() == 0)
                return View("index");

            Book.Id = data[0].Id;
            Book.Title = data[0].Title;
            Book.AuthorFirstName = data[0].Author_first_name;
            Book.AuthorLastName = data[0].Author_last_name;
            Book.Description = data[0].Short_desc;
            Book.Price = data[0].Price;
            Book.Amount = data[0].Amount;
            Book.Genre_name = data[0].Genre_name;

            return View(Book);
        }
        public ActionResult BookReviews(int id)
        {
            var data = ReviewProcessor.LoadReviewsByBookId(id);
            List<ReviewModel> reviews = new List<ReviewModel>();

            foreach (var review in data)
            {
                reviews.Add(new ReviewModel
                {
                    Id = review.Id,
                    BookId = review.BookId,
                    Username=review.Username,
                    Rating = review.Rating,
                    TextReview=review.TextReview
                }
                    );
            }

            return View(reviews);
        }

        /*public ActionResult OrderDetails(int id)
        {
            /*ViewBag.Message = "Order details."

            ViewData["Order"] =
            ViewData["OrderDetails"]
            return View(Order);*/
        //}

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
                    Price = book.Price,
                    Genre_name = book.Genre_name
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

        public ActionResult DeleteFromCart(int id)
        {
            List<CartItemModel> cartItems = (List<CartItemModel>)Session["cart"];
            bool found = false;

            if (Session["cart"] == null)
            {
                return RedirectToAction("ViewAllBooks");
            }
            else
            {  
                for (int i=0;i<cartItems.Capacity;i++)
                {
                    if (cartItems[i].BookId == id)
                    {
                        cartItems.RemoveAt(i);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    return RedirectToAction("Cart");
                }
            }

                Session["cart"] = cartItems;

                return RedirectToAction("Cart");
        }

        public ActionResult Buy()
        {
            ViewBag.Message = "Go to buy screen.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(OrderModel model)
        {
            List<CartItemModel> cart = (List<CartItemModel>)Session["cart"];
            decimal total = cart.Sum(item => item.Total * item.Count);
            model.TotalCost = total;
            
            if (ModelState.IsValid && cart.Count>0)
            {
                var data = OrderProcessor.PlaceOrder(model.FirstName, model.LastName, model.City, model.Address, model.Apartment, model.Postcode, model.TotalCost);
                
                foreach (CartItemModel item in cart)
                {
                    OrderDetailModel detail = new OrderDetailModel
                    {
                        OrderId = data[0].Id,
                        BookId = item.BookId,
                        Amount = item.Count
                    };
                    OrderProcessor.AddOrderDetails(detail.OrderId,detail.BookId,detail.Amount);
                }

                return RedirectToAction("index");
            }

            return RedirectToAction("ViewAllBooks");
        }

        public ActionResult ViewOrders()
        {
            ViewBag.Message = "List of all orders.";

            var data = OrderProcessor.LoadOrders();
            List<OrderModel> orders = new List<OrderModel>();

            foreach (var order in data)
            {
                orders.Add(new OrderModel
                {
                    Id = order.Id,
                    FirstName = order.FirstName,
                    LastName = order.LastName,
                    City = order.City,
                    Address = order.Address,
                    Apartment = order.Apartment,
                    Postcode = order.Postcode,
                    TotalCost = order.TotalCost,
                    Status = order.Status,
                    OrderDate = order.OrderDate
                }
                    );
            }

            return View(orders);
        }

    }
}