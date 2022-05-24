using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StronaZKsiazkami.Models
{
    public class ShoppingCart
    {
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        
        public void AddToCart(BookModel book)
        {

        }
     }
}